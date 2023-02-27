using StateMachine;

public class CharacterIdleState : State
{
    private readonly CharacterAnimationController m_characterAnimationController;

    public CharacterIdleState(CharacterAnimationController characterAnimationController)
    {
        m_characterAnimationController = characterAnimationController;
    }

    public override void OnStateEnter()
    {
        m_characterAnimationController.SetBool(CharacterAnimationType.Idle, true);
    }

    public override void OnStateExit()
    {
        m_characterAnimationController.SetBool(CharacterAnimationType.Idle, false);
    }
}