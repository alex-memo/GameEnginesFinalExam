using System.Collections;
using UnityEngine;

public class GameManager : InstanceFactory<GameManager>
{
	public OnDuckKilled OnDuckKilled;
	[SerializeField] private Vector2 xPositions = new();
	[SerializeField] private Vector2 yBoundsRange = new(-3.5f, 3.5f);
	[SerializeField] private float zPosition = 0;
	private float spawnRate = 1;
	private void Start()
	{
		//StartCoroutine(gameLoop());
		DuckPool.Instance.GetDuck();
	}
	protected override void OnDestroy()
	{
		base.OnDestroy();
		OnDuckKilled = null;
	}
	private IEnumerator gameLoop()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnRate);
			DuckPool.Instance.GetDuck();
		}
	}
	public Vector3 GetSpawnPos(out Quaternion _rotation)
	{
		// we get one of the x positions out of the 2 available
		float _x = Random.value > 0.5f ? xPositions.x : xPositions.y;
		//y pos we get from the range 
		float _y = Random.Range(yBoundsRange.x, yBoundsRange.y);
		//we spawn them looking to left or right, if x is negative, we look to the right
		_rotation = Quaternion.Euler(0, _x < 0 ? 90 : -90, 0);
		return new Vector3(_x, _y, zPosition);
	}
}
public delegate void OnDuckKilled();