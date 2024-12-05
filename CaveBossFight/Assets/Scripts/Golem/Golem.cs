using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
	public float _maxHp = 100f;
	public float _hp;

	[Header("UI")]
	public Slider _healthBar;

	void Start()
	{
		_hp = _maxHp;

		_healthBar.maxValue = _maxHp;
		_healthBar.value = _hp;
	}

	public void TakeDamage(float damage)
	{
		_hp -= damage;
		_hp = Mathf.Clamp(_hp, 0, _maxHp);

		UpdateHealthUI();
	}

	public void Heal(float healAmount)
	{
		_hp += healAmount;
		_hp = Mathf.Clamp(_hp, 0, _maxHp);

		UpdateHealthUI();
	}

	private void UpdateHealthUI()
	{
		_healthBar.value = _hp;
	}
}