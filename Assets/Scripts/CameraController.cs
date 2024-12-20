using UnityEngine;

public class CameraController : MonoBehaviour
{
	private float cameraCap;
	private Vector2 currentMouseDelta;
	private Vector2 currentMouseDeltaVelocity;

	[SerializeField] private Transform playerCam;

	[SerializeField] private float mouseSens = 2.5f;
	[SerializeField][Range(0, .5f)] private float mouseSmoothTime = .03f;

	[SerializeField] private bool cursorLock = true;

	private void Start()
	{
		if (cursorLock)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		InputManager.Instance.OnMouseDelta += updateMouse;
	}
	private void updateMouse(Vector2 _delta)
	{
		currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, _delta, ref currentMouseDeltaVelocity, mouseSmoothTime);
		cameraCap -= currentMouseDelta.y * mouseSens;
		cameraCap = Mathf.Clamp(cameraCap, -90, 90);
		playerCam.localEulerAngles = Vector3.right * cameraCap;
		transform.Rotate(currentMouseDelta.x * mouseSens * Vector3.up);
	}
}
