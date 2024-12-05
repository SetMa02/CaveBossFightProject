using UnityEngine;

public class InputHandler : MonoBehaviour
{
	public Vector2 GetMovementInput()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		return new Vector2(moveX, 0).normalized;
	}

	public bool IsAttackPressed()
	{
		return Input.GetMouseButtonDown(0);
	}

	public bool IsHeavyAttackPressed()
	{
		return Input.GetMouseButtonDown(1);
	}

	public bool IsAnyAttackPressed()
	{
		return IsAttackPressed() || IsHeavyAttackPressed();
	}

	public bool IsJumpPressed()
	{
		return Input.GetKeyDown(KeyCode.Space);
	}
}
