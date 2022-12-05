using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent; 
    public VariableJoystick joystick;
    public float Speed = 10;
    private PlayerAnimationControl playerAnimCtrl;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerAnimCtrl = GetComponent<PlayerAnimationControl>();
    }
    private void Update()
    {
        if (!joystick) return;
        if(joystick.Direction == Vector2.zero)
        {
            playerAnimCtrl.PlayIdleAnim();
            return;
        }
        else
        {
            Vector3 move = new Vector3(joystick.Direction.x * Speed * Time.deltaTime, 0, joystick.Direction.y * Speed * Time.deltaTime);
            agent.Move(move);
            agent.SetDestination(transform.position + move);
            playerAnimCtrl.PlayWalkAnim(agent.velocity.magnitude);
        }
        

    }
}
