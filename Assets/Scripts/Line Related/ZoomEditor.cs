using UnityEngine;

public class ZoomEditor : ILineEditor
{
    private readonly CameraZoom _cameraZoom;
    private float _lastYPos;

    public ZoomEditor() => _cameraZoom = LineManager.Instance.Camera.GetComponent<CameraZoom>();

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastYPos = Input.mousePosition.y;
            return;
        }
        if(!Input.GetMouseButton(0))
            return;
        _cameraZoom.Zoom((Input.mousePosition.y - _lastYPos) / 200f);
        _lastYPos = Input.mousePosition.y;
    }
}