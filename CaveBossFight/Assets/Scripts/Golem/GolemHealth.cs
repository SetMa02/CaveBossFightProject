using UnityEngine;
using UnityEngine.UI;

public class GolemHealth : MonoBehaviour, IDamageable
{
	[SerializeField] private int _maxHealth = 100;
	[SerializeField] private Slider _healthBar;

	private int _currentHealth;

	void Awake()
	{
		this._currentHealth = this._maxHealth;
		if (this._healthBar != null)
		{
			this._healthBar.value = 1f;
		}
	}

	public void TakeDamage(int amount)
	{
		this._currentHealth -= amount;
		Debug.Log("Golem took damage. Current Health: " + this._currentHealth);
		if (this._currentHealth < 0)
		{
			this._currentHealth = 0;
		}

		if (this._healthBar != null)
		{
			float normalizedValue = (float)this._currentHealth / (float)this._maxHealth;
			this._healthBar.value = normalizedValue;
		}

		if (this._currentHealth <= 0)
		{
			// death
		}
	}
}
