using UnityEngine;

public class AttackController : MonoBehaviour
{
	[SerializeField] private LayerMask _damageableLayer;
	[SerializeField] private float _closeAttackRadius = 1f;
	[SerializeField] private int _closeAttackDamage = 10;

	public void PerformCloseAttack(Vector3 center)
	{
		Collider[] hits = Physics.OverlapSphere(center, this._closeAttackRadius, this._damageableLayer);
		Debug.Log("Close attack performed. Hits found: " + hits.Length);
		foreach (Collider hit in hits)
		{
			Debug.Log("Hit: " + hit.name);
			IDamageable damageable = hit.GetComponent<IDamageable>();
			if (damageable != null)
			{
				damageable.TakeDamage(this._closeAttackDamage);
			}
			else
			{
				Debug.Log("No IDamageable on: " + hit.name);
			}
		}
	}
}
