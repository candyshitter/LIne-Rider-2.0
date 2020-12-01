using UnityEngine;

public class CameraMove : MonoBehaviour
{
	private Camera _camera;
	public Vector3 StartPosition { get; set; }
	public Vector3 MouseToWorld => _camera.ScreenToWorldPoint(Input.mousePosition);

	private void Awake() => _camera = GetComponent<Camera>();

	private void Update()
	{
		if (Input.GetMouseButtonDown(2))
			StartPosition = MouseToWorld;
		if (!Input.GetMouseButton(2)) return;
		MoveCamera(MouseToWorld);
	}

	public void MoveCamera(Vector3 inputPos) => 
		_camera.transform.position += StartPosition - inputPos;
}