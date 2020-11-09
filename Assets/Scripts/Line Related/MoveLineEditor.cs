using UnityEngine;

public class MoveLineEditor : BaseEditor
{
	private Vector2 _offset;

	protected override void CheckForLine()
	{
		if (!Input.GetMouseButton(0) || CurrentLine != null) return;
		
		CurrentLine = camera.GetComponentAtScreenPosition<Line>(Input.mousePosition);
		if (CurrentLine == null) return;
		_offset = (Vector2) CurrentLine.transform.position - MouseWorldPos;
	}

	protected override bool StopEditing() => Input.GetMouseButtonUp(0);

	protected override void UpdateLine() => CurrentLine.transform.position = MouseWorldPos + _offset;
}