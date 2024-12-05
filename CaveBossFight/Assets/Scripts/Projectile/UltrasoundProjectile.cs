using UnityEngine;

public class UltrasoundProjectile : MonoBehaviour
{
	public float speed = 10f;
	public float lifeTime = 2f;

	private float _lifeTimer;
	private Vector2 _direction;
	private Transform _playerTransform;

	public void Initialize(Transform player)
	{
		this._playerTransform = player;
		this._lifeTimer = this.lifeTime;

		float playerScaleX = this._playerTransform.localScale.x;
		if (playerScaleX > 0)
		{
			this._direction = Vector2.right;
		}
		else
		{
			this._direction = Vector2.left;
		}

		Vector3 spawnOffset = new Vector3(this._direction.x * 0.5f, 0.5f, 0f);
		this.transform.position = this._playerTransform.position + spawnOffset;

		float angle = Mathf.Atan2(this._direction.y, this._direction.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.Euler(0f, 0f, angle);
	}

	void Update()
	{
		this.transform.Translate(this._direction * this.speed * Time.deltaTime, Space.World);
		this._lifeTimer -= Time.deltaTime;
		if (this._lifeTimer <= 0f)
		{
			ProjectilePool.Instance.ReturnProjectile(this.gameObject);
		}
	}
}
