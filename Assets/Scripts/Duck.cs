using UnityEngine;

public class Duck : MonoBehaviour
{
	public static float Speed = 7;
	public static float lifeTime = 5;
	private Rigidbody rb;
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	private void OnEnable()
	{
		rb.linearVelocity = transform.forward * Speed;
		Invoke(nameof(Disable), lifeTime);
	}
	private void Disable()
	{
		gameObject.SetActive(false);
	}
	public void Die()
	{
		GameManager.Instance.OnDuckKilled?.Invoke();
		CancelInvoke(nameof(Disable));
		gameObject.SetActive(false);
	}
}
