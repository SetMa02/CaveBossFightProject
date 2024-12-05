using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimation), typeof(InputHandler))]
public class PlayerController : MonoBehaviour
{
	private PlayerMovement _movement;
	private PlayerAnimation _animationController;
	private InputHandler _inputHandler;

	private bool _isAttacking = false;
	private bool _isHeavyAttacking = false;
	private bool _isJumping = false;

	// Настройте эти параметры по желанию
	public float _attackRange = 1f;
	public LayerMask _bossLayer;

	void Awake()
	{
		this._movement = this.GetComponent<PlayerMovement>();
		this._animationController = this.GetComponent<PlayerAnimation>();
		this._inputHandler = this.GetComponent<InputHandler>();
	}

	void Update()
	{
		this.HandleMovement();
		this.HandleActions();
	}

	private void HandleMovement()
	{
		Vector2 direction = this._inputHandler.GetMovementInput();
		this._movement.Move(direction);
		this._animationController.SetMovement(direction);

		if (this._inputHandler.IsJumpPressed())
		{
			this._movement.Jump();
			this._animationController.Jump(true);
			this._isJumping = true;
		}

		if (this._isJumping && this._movement.IsGrounded())
		{
			this._animationController.Jump(false);
			this._isJumping = false;
		}
	}

	private void HandleActions()
	{
		if (this._isAttacking || this._isHeavyAttacking)
		{
			return;
		}

		if (this._inputHandler.IsAttackPressed())
		{
			StartCoroutine(this.HandleAttack());
		}
		if (this._inputHandler.IsHeavyAttackPressed())
		{
			StartCoroutine(this.HandleHeavyAttack());
		}

		if (!this._inputHandler.IsAnyAttackPressed() && !this._movement.IsMoving() && !this._isAttacking && !this._isHeavyAttacking && !this._isJumping)
		{
			this._animationController.Idle();
		}
	}

	private IEnumerator HandleAttack()
	{
		this._isAttacking = true;
		this._animationController.Attack();

		yield return new WaitForSeconds(this.GetAnimationLength("Attack"));

		// После завершения анимации атаки проверяем попадание по боссу
		PerformMeleeAttack();

		this._isAttacking = false;
	}

	private IEnumerator HandleHeavyAttack()
	{
		this._isHeavyAttacking = true;
		this._animationController.HeavyAttack();
		this.SpawnUltrasoundProjectile();
		yield return new WaitForSeconds(this.GetAnimationLength("HeavyAttack"));
		this._isHeavyAttacking = false;
	}

	private void SpawnUltrasoundProjectile()
	{
		GameObject projectile = ProjectilePool.Instance.GetProjectile();
		projectile.GetComponent<UltrasoundProjectile>().Initialize(this.transform);
	}

	private float GetAnimationLength(string animationName)
	{
		RuntimeAnimatorController ac = this._animationController.GetComponent<Animator>().runtimeAnimatorController;
		foreach (AnimationClip clip in ac.animationClips)
		{
			if (clip.name == animationName)
			{
				return clip.length;
			}
		}
		return 0.5f;
	}

	public void OnAttackComplete()
	{
		this._isAttacking = false;
	}

	public void OnHeavyAttackComplete()
	{
		this._isHeavyAttacking = false;
	}

	private void PerformMeleeAttack()
	{
		Vector3 attackPosition = this.transform.position + new Vector3(this.transform.localScale.x * 0.5f, 0f, 0f);
		Collider2D hit = Physics2D.OverlapCircle(attackPosition, this._attackRange, this._bossLayer);
		if (hit != null)
		{
			Golem health = hit.GetComponent<Golem>();
			if (health != null)
			{
				health.TakeDamage(10f); // Ближняя атака наносит 10 урона
			}
		}
	}
}
