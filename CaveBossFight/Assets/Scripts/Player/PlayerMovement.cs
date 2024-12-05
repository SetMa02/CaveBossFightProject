using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float jumpForce = 5f;
	public LayerMask groundLayer;

	private Rigidbody2D rb;
	private BoxCollider2D boxCollider;
	private Vector2 movement;
	private bool isGrounded;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		isGrounded = boxCollider.IsTouchingLayers(groundLayer);
	}

	public void Move(Vector2 direction)
	{
		movement = direction * moveSpeed;
	}

	public void Jump()
	{
		if (isGrounded)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2(movement.x, rb.velocity.y);
	}

	public bool IsMoving()
	{
		return movement.x != 0;
	}

	public bool IsGrounded()
	{
		return isGrounded;
	}
}
