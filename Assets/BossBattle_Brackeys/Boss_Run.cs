﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{

	public float speed = 2.5f;
	public float attackRange = 3f;

	[SerializeField] Transform player;
	[SerializeField] Rigidbody2D rb;
	[SerializeField] Boss boss;
	[SerializeField] private Transform bossTransform;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody2D>();
		boss = animator.GetComponent<Boss>();
		bossTransform = animator.GetComponent<Transform>().transform;
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		boss.LookAtPlayer();

		Vector2 target = new Vector2(player.position.x, rb.position.y);
		Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
		rb.MovePosition(newPos);

		Debug.Log("target: " + target);
		Debug.Log("newPos: " + newPos);
		Debug.Log("rb position: " + rb.position);
		Debug.Log("maxDist: " + speed * Time.fixedDeltaTime);
		
		if (Vector2.Distance(player.position, rb.position) <= attackRange)
		{
			animator.SetTrigger("Attack");
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("Attack");
	}
}
