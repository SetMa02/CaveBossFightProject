using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
	private Animator _animator;
	private bool _facingRight = true;

	private const string IsWalkingParam = "isWalking";
	private const string IsJumpingParam = "isJumping";
	private const string AttackTrigger = "Attack";
	private const string HeavyAttackTrigger = "HeavyAttack";

	void Awake()
	{
		this._animator = this.GetComponent<Animator>();
	}

	public void SetMovement(Vector2 direction)
	{
		bool isMoving = direction.magnitude > 0;
		this._animator.SetBool(IsWalkingParam, isMoving);
		if (isMoving)
		{
			if (direction.x > 0 && !this._facingRight)
			{
				this.Flip();
			}
			else if (direction.x < 0 && this._facingRight)
			{
				this.Flip();
			}
		}
	}

	public void Attack()
	{
		this._animator.SetTrigger(AttackTrigger);
	}

	public void HeavyAttack()
	{
		this._animator.SetTrigger(HeavyAttackTrigger);
	}

	public void Idle()
	{
		this._animator.SetBool(IsWalkingParam, false);
	}

	public void Jump(bool isJumping)
	{
		this._animator.SetBool(IsJumpingParam, isJumping);
	}

	private void Flip()
	{
		this._facingRight = !this._facingRight;
		Vector3 scale = this.transform.localScale;
		scale.x = Mathf.Abs(scale.x) * (this._facingRight ? 1 : -1);
		this.transform.localScale = scale;
	}
}
