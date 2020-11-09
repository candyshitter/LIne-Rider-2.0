using UnityEngine;

public abstract class BaseEraseEditor : BaseEditor
{
	protected override void CheckForLine()
	{
		if (!Input.GetMouseButton(0)) return;
		var line = camera.GetComponentAtScreenPosition<Line>(Input.mousePosition);
		if (line == null) return;
		CurrentLine = line;
	}

	protected override bool StopEditing() => Input.GetMouseButtonUp(0);
}