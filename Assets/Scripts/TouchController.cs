using System;
using UnityEngine;

public class TouchController : MonoBehaviour
{
	private CameraZoom _zoomer;
	private CameraMove _mover;
	private Camera _camera;

	private void Awake()
	{
		_camera = FindObjectOfType<Camera>();
		_zoomer = FindObjectOfType<CameraZoom>();
		_mover = FindObjectOfType<CameraMove>();
	}

	private void Update()
	{
		if (Input.touchCount != 2) return;
		var touch1 = Input.GetTouch(0);
		var touch2 = Input.GetTouch(1);
		PinchToZoom(touch1, touch2);
		PanCamera(touch1, touch2);
	}
	

	private void PanCamera(Touch touch1, Touch touch2)
	{
		var center = (touch1.position - touch2.position) / 2;
		center = _camera.ScreenToWorldPoint(center);
		if (touch2.phase == TouchPhase.Began)
			_mover.StartPosition = _mover.MouseToWorld;
		_mover.MoveCamera(center);
	}



	private void PinchToZoom(Touch touch1, Touch touch2) =>
		_zoomer.Zoom(
			touch1.deltaPosition.magnitude + 
			touch2.deltaPosition.magnitude);
	
}