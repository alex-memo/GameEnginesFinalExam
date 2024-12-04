using System.Collections.Generic;
using UnityEngine;

public class DuckPool : InstanceFactory<DuckPool>
{
	[SerializeField] private Duck duckPrefab;
	protected List<Duck> ducks = new();
	public void GetDuck()
	{
		getDuckFromPool();
	}
	private void spawnNewDuck()
	{
		var _pos = getSpawnPos(out var _rotation);
		Duck _duck = Instantiate(duckPrefab, _pos, _rotation, transform);
		ducks.Add(_duck);
	}
	private void getDuckFromPool()
	{
		Duck _duck = ducks.Find(duck => !duck.gameObject.activeSelf);
		if (_duck == null)
		{
			spawnNewDuck();
		}
		else
		{
			var _pos = getSpawnPos(out var _rotation);
			_duck.transform.SetPositionAndRotation(_pos, _rotation);
			_duck.gameObject.SetActive(true);
		}
	}
	private Vector3 getSpawnPos(out Quaternion _rotation)
	{
		return GameManager.Instance.GetSpawnPos(out _rotation);

	}
}
