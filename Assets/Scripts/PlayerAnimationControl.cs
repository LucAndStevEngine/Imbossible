using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    private float m_currentAnimLength = 0;


    // Use this for initialization
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }


    public void SetSpeed(float speed)
    {
        m_Animator.SetFloat("Speed", speed);
    }

    public void UseAnimation(Enumeration.AnimationUse animationUsed)
    {
        m_Animator.SetTrigger(animationUsed.ToString());
    }

    public float GetAnimationLength(Enumeration.AnimationUse animationUsed)
    {
        AnimationClip[] clips = m_Animator.runtimeAnimatorController.animationClips;

        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].name == animationUsed.ToString())
            {
                return clips[i].length;
            }
        }
        return 0;
    }


}
