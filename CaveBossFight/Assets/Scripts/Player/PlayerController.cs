using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimation), typeof(InputHandler))]
public class PlayerController : MonoBehaviour
{
	private PlayerMovement movement;
	private PlayerAnimation animationController;
	private InputHandler inputHandler;

	private bool isAttacking = false;
	private bool isHeavyAttacking = false;
	private bool isJumping = false;

	void Awake()
	{
		movement = GetComponent<PlayerMovement>();
		animationController = GetComponent<PlayerAnimation>();
		inputHandler = GetComponent<InputHandler>();
	}

	void Update()
	{
		HandleMovement();
		HandleActions();
	}

	private void HandleMovement()
	{
		Vector2 direction = inputHandler.GetMovementInput();
		movement.Move(direction);
		animationController.SetMovement(direction);

		if (inputHandler.IsJumpPressed())
		{
			movement.Jump();
			animationController.Jump(true);
			isJumping = true;
		}

		if (isJumping && movement.IsGrounded())
		{
			animationController.Jump(false);
			isJumping = false;
		}
	}

	private void HandleActions()
	{
		if (isAttacking || isHeavyAttacking)
			return;

		if (inputHandler.IsAttackPressed())
		{
			StartCoroutine(HandleAttack());
		}
		if (inputHandler.IsHeavyAttackPressed())
		{
			StartCoroutine(HandleHeavyAttack());
		}

		if (!inputHandler.IsAnyAttackPressed() && !movement.IsMoving() && !isAttacking && !isHeavyAttacking && !isJumping)
		{
			animationController.Idle();
		}
	}

	private IEnumerator HandleAttack()
	{
		isAttacking = true;
		animationController.Attack();
		yield return new WaitForSeconds(GetAnimationLength("Attack"));
		isAttacking = false;
	}

	private IEnumerator HandleHeavyAttack()
	{
		isHeavyAttacking = true;
		animationController.HeavyAttack();
		yield return new WaitForSeconds(GetAnimationLength("HeavyAttack"));
		isHeavyAttacking = false;
	}

	private float GetAnimationLength(string animationName)
	{
		RuntimeAnimatorController ac = animationController.GetComponent<Animator>().runtimeAnimatorController;
		foreach (var clip in ac.animationClips)
		{
			if (clip.name == animationName)
				return clip.length;
		}
		return 0.5f;
	}

	public void OnAttackComplete()
	{
		isAttacking = false;
	}

	public void OnHeavyAttackComplete()
	{
		isHeavyAttacking = false;
	}
}
