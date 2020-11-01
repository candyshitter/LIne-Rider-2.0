using UnityEngine;

public class CameraMove : MonoBehaviour
{
	private Camera _camera;
	private Vector3 _startPosition;

	private void Awake() => _camera = GetComponent<Camera>();

	private void Update()
	{
		if (Input.GetMouseButtonDown(2)) 
			_startPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
		if (!Input.GetMouseButton(2)) return;
		var direction = _startPosition - _camera.ScreenToWorldPoint(Input.mousePosition);
		_camera.transform.position += direction;
	}
}