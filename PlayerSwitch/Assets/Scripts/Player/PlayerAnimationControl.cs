using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    Animator animator;
    const string SpeedParameter = "Speed";
    const string IsWalkingParameter = "isWalking";
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void PlayIdleAnim()
    {
        animator.SetBool(IsWalkingParameter, false);
    }
    public void PlayWalkAnim(float speed)
    {
        animator.SetBool(IsWalkingParameter, true);
        PlayAnim(speed);
    }
    public void PlayAnim(float speed)
    {
        animator.SetFloat(SpeedParameter, speed);
    }
}
