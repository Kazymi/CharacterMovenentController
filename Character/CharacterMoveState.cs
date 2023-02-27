using StateMachine;
using UnityEngine;

public class CharacterMoveState : State
{
    private readonly Rigidbody m_rigidbody;
    private readonly CharacterConfigurations m_characterConfigurations;
    private readonly Joystick m_joystick;
    private readonly CharacterAnimationController m_characterAnimationController;

    public CharacterMoveState(Rigidbody rigidbody, CharacterConfigurations characterConfigurations, Joystick joystick,
        CharacterAnimationController
            characterAnimationController)
    {
        m_rigidbody = rigidbody;
        m_characterConfigurations = characterConfigurations;
        m_joystick = joystick;
        m_characterAnimationController = characterAnimationController;
    }

    public override void Tick()
    {
        if (m_joystick.Direction != Vector2.zero)
        {
            var delta = Time.deltaTime;
            Rotate(m_joystick.Direction, delta);
            Move(m_joystick.Direction, delta);
        }
    }

    public override void OnStateEnter()
    {
        m_characterAnimationController.SetBool(CharacterAnimationType.Walk, true);
    }

    public override void OnStateExit()
    {
        m_characterAnimationController.SetBool(CharacterAnimationType.Walk, false);
    }

    private void Rotate(Vector2 joystickDirection, float deltaTime)
    {
        var rb = m_rigidbody;
        var charForward = rb.transform.forward;
        var direction = new Vector3(joystickDirection.x, 0, joystickDirection.y).normalized;
        var speed = m_characterConfigurations.SpeedRotate * deltaTime;

        var newDirection = Vector3.RotateTowards(charForward, direction, speed, 0.0f);
        rb.transform.rotation =
            Quaternion.Lerp(m_rigidbody.transform.rotation, Quaternion.LookRotation(newDirection), 1);
    }

    private void Move(Vector2 joystickDirection, float deltaTime)
    {
        var rb = m_rigidbody;
        var charForward = rb.transform.forward;
        var speed = m_characterConfigurations.Speed;
        speed *= joystickDirection.magnitude;
        var velocity = charForward * (speed * deltaTime);
        rb.velocity = velocity;
    }
}