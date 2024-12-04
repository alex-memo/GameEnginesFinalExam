using UnityEngine;

public class CameraLaser : MonoBehaviour
{
	private Transform cam;
	private void Awake()
	{
		cam = Camera.main.transform;
	}
	private void Start()
	{
		InputManager.Instance.OnMouseClick += shootLaser;
	}
	private void shootLaser()
	{
		Ray _ray = new(cam.position, cam.forward);
		if (Physics.Raycast(_ray, out RaycastHit _hit, 100))
		{
			Debug.Log("Hit: " + _hit.transform.name);
		}
		else
		{
			Debug.Log("Miss");
		}
	}
}
