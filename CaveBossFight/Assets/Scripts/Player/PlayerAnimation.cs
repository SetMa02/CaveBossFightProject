using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
	private Animator animator;
	private bool facingRight = true;

	private const string IsWalkingParam = "isWalking";
	private const string IsJumpingParam = "isJumping";
	private const string AttackTrigger = "Attack";
	private const string HeavyAttackTrigger = "HeavyAttack";

	void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void SetMovement(Vector2 direction)
	{
		bool isMoving = direction.magnitude > 0;
		animator.SetBool(IsWalkingParam, isMoving);
		if (isMoving)
		{
			if (direction.x > 0 && !facingRight)
				Flip();
			else if (direction.x < 0 && facingRight)
				Flip();
		}
	}

	public void Attack()
	{
		animator.SetTrigger(AttackTrigger);
	}

	public void HeavyAttack()
	{
		animator.SetTrigger(HeavyAttackTrigger);
	}

	public void Idle()
	{
		animator.SetBool(IsWalkingParam, false);
	}

	public void Jump(bool isJumping)
	{
		animator.SetBool(IsJumpingParam, isJumping);
	}

	private void Flip()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x = Mathf.Abs(scale.x) * (facingRight ? 1 : -1);
		transform.localScale = scale;
	}
}
