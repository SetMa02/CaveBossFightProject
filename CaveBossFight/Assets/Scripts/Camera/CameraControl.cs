using UnityEngine;

public class AdvancedCameraParallax : MonoBehaviour
{
	[SerializeField] private Transform player;
	[SerializeField] private float baseParallaxSpeed = 0.05f;
	[SerializeField] private float backgroundParallaxSpeed = 0.02f;
	[SerializeField] private float movementDivider = 10f;

	[SerializeField] private float mapWidth = 100f;
	[SerializeField] private float mapHeight = 100f;

	private Vector3 lastPlayerPosition;
	private Vector3 initialCameraPosition;

	private void Start()
	{
		lastPlayerPosition = player.position;
		initialCameraPosition = transform.position;
	}

	private void LateUpdate()
	{
		Vector3 playerMovement = player.position - lastPlayerPosition;

		Vector3 baseParallax = playerMovement * (baseParallaxSpeed / movementDivider);
		Vector3 backgroundParallax = playerMovement * (backgroundParallaxSpeed / movementDivider);

		Vector3 newPosition = transform.position + baseParallax;

		newPosition.x = Mathf.Clamp(
			newPosition.x,
			initialCameraPosition.x - mapWidth / 2f,
			initialCameraPosition.x + mapWidth / 2f
		);

		newPosition.y = Mathf.Clamp(
			newPosition.y,
			initialCameraPosition.y - mapHeight / 2f,
			initialCameraPosition.y + mapHeight / 2f
		);

		transform.position = newPosition;

		lastPlayerPosition = player.position;
	}
}