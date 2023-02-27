using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController
{
    private readonly Animator m_animator;
    private Dictionary<CharacterAnimationType, int> m_animationHashes = new Dictionary<CharacterAnimationType, int>();

    public CharacterAnimationController(Animator animator)
    {
        m_animator = animator;
        foreach (CharacterAnimationType animationType in Enum.GetValues(typeof(CharacterAnimationType)))
        {
            m_animationHashes.Add(animationType, Animator.StringToHash(
                animationType.ToString()));
        }
    }

    public void SetBool(CharacterAnimationType characterAnimationType, bool value)
    {
        m_animator.SetBool(m_animationHashes[characterAnimationType], value);
    }

    public void SetPlay(CharacterAnimationType characterAnimationType, bool isTrigger = false, int layer = 0,
        float time = 0)
    {
        if (isTrigger)
        {
            m_animator.SetTrigger(m_animationHashes[characterAnimationType]);
        }
        else
        {
            m_animator.Play(m_animationHashes[characterAnimationType], layer, time);
        }
    }
}