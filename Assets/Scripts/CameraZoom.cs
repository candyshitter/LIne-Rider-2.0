using UnityEngine;

public class CameraZoom : MonoBehaviour
{
	[SerializeField] private float minZoom = 3;
	[SerializeField] private float maxZoom = 20;
	[SerializeField] private float zoomStep = 8;
	[SerializeField] private float zoomLerpSpeed = 15;
	private Camera _camera;
	private float _targetZoom;

	private void Awake()
	{
		_camera = GetComponent<Camera>();
		_targetZoom = _camera.orthographicSize;
	}

	private void Update()
	{
		var zoom = Input.GetAxis("Mouse ScrollWheel");
		_targetZoom -= zoom * zoomStep;
		_targetZoom = Mathf.Clamp(_targetZoom, minZoom, maxZoom);
		_camera.orthographicSize = Mathf.Lerp(
			_camera.orthographicSize, 
			_targetZoom, 
			Time.deltaTime * zoomLerpSpeed);
	}
}