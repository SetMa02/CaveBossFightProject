using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float jumpForce = 5f;
	public LayerMask groundLayer;

	private Rigidbody2D _rb;
	private BoxCollider2D _boxCollider;
	private Vector2 _movement;
	private bool _isGrounded;

	void Awake()
	{
		this._rb = this.GetComponent<Rigidbody2D>();
		this._boxCollider = this.GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		this._isGrounded = this._boxCollider.IsTouchingLayers(this.groundLayer);
	}

	public void Move(Vector2 direction)
	{
		this._movement = direction * this.moveSpeed;
	}

	public void Jump()
	{
		if (this._isGrounded)
		{
			this._rb.velocity = new Vector2(this._rb.velocity.x, this.jumpForce);
		}
	}

	void FixedUpdate()
	{
		this._rb.velocity = new Vector2(this._movement.x, this._rb.velocity.y);
	}

	public bool IsMoving()
	{
		return this._movement.x != 0;
	}

	public bool IsGrounded()
	{
		return this._isGrounded;
	}
}
