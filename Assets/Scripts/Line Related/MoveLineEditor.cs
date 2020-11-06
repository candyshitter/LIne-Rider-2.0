using UnityEngine;

public class MoveLineEditor : BaseEditor, ILineEditor
{
	private Vector2 _offset;
	public MoveLineEditor(LineManager lineManager, Camera camera) : base(lineManager, camera) { }
	public Line CurrentLine { get; set; }

	public void CheckForLine()
	{
		if (!Input.GetMouseButton(0) || CurrentLine != null) return;
		
		CurrentLine = camera.GetComponentAtScreenPosition<Line>(Input.mousePosition);
		if (CurrentLine == null) return;
		Debug.Log("hollo");
		_offset = (Vector2) CurrentLine.transform.position - MouseWorldPos;
	}

	public bool StopEditing() => Input.GetMouseButtonUp(0);
	public void UpdateLine()
	{
		CurrentLine.transform.position = MouseWorldPos + _offset;
		Debug.Log("moving");
	}
}