using UnityEngine;

public class PanEditor : ILineEditor
{
    private CameraMove _cameraMove;

    public PanEditor() => 
        _cameraMove = LineManager.Instance.Camera.GetComponent<CameraMove>();
	
    public void Tick()
    {
        if (Input.GetMouseButtonDown(0)) 
            _cameraMove.StartPosition = _cameraMove.MouseToWorld;
        if (!Input.GetMouseButton(0)) return;
        _cameraMove.MoveCamera(_cameraMove.MouseToWorld);
    }
}