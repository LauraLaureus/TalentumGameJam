using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {


    Animator animator;

	// Use this for initialization
	void Start () {
        PlayerMovement.OnKeyPressed += OnKeyPressed_HandleAnimation;
        animator = GetComponent<Animator>();
	}

    public void OnKeyPressed_HandleAnimation(PlayerMovement.MovementEnum e)
    {
        //TODO take the current animation name 
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(e.ToString()))
        {
            if (e == PlayerMovement.MovementEnum.Down)
            {
                animator.SetInteger("movement", 1);
            }
            else if (e == PlayerMovement.MovementEnum.Up)
            {
                animator.SetInteger("movement", 2);
            }
            else if (e == PlayerMovement.MovementEnum.Right)
            {
                animator.SetInteger("movement", 3);

            }
            else if (e == PlayerMovement.MovementEnum.Left)
            {
                animator.SetInteger("movement", 4);
            }
            else if (e == PlayerMovement.MovementEnum.Idle)
            {
                animator.SetInteger("movement", 0);
            }
        }
    }
}
