using UnityEngine;
using System.Collections.Generic;

public class ProjectilePool : MonoBehaviour
{
	public static ProjectilePool Instance;

	public GameObject projectilePrefab;
	public int poolSize = 10;

	private Queue<GameObject> _projectilePool = new Queue<GameObject>();

	void Awake()
	{
		// чтоб точно сохранить свой екземпляр
		Instance = this;
		for (int i = 0; i < this.poolSize; i++)
		{
			GameObject proj = Instantiate(this.projectilePrefab, this.transform);
			proj.SetActive(false);
			this._projectilePool.Enqueue(proj);
		}
	}

	public GameObject GetProjectile()
	{
		GameObject proj;
		if (this._projectilePool.Count > 0)
		{
			proj = this._projectilePool.Dequeue();
			proj.SetActive(true);
		}
		else
		{
			proj = Instantiate(this.projectilePrefab, this.transform);
		}
		proj.transform.SetParent(this.transform);
		return proj;
	}

	public void ReturnProjectile(GameObject proj)
	{
		proj.SetActive(false);
		proj.transform.SetParent(this.transform);
		this._projectilePool.Enqueue(proj);
	}
}
