using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationReset : MonoBehaviour
{
    [SerializeField] private Animator[] m_animator;

	public void AnimReset()
    {
        foreach (var anim in m_animator)
        {
            anim.Play("Closing");
            anim.Play("Closing 1");
            anim.Play("ClosingOven");
        }
    }
}
