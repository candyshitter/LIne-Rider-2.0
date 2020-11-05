using UnityEngine;

public class MoveLineEditor : BaseEditor, ILineEditor
{
	private Vector2 _offset;
	public MoveLineEditor(LineManager lineManager, Camera camera) : base(lineManager, camera) { }
	public Line CurrentLine { get; set; }

	public void CheckForLine()
	{
		if (!Input.GetMouseButton(0) || CurrentLine != null) return;
		
		var line = camera.GetComponentAtScreenPosition<Line>();
		if (line == null) return;
		CurrentLine = line;
		_offset = (Vector2) CurrentLine.transform.position - MouseWorldPos;
	}

	public bool StopEditing() => Input.GetMouseButtonUp(0);
	public void UpdateLine() => CurrentLine.transform.position = MouseWorldPos + _offset;
}