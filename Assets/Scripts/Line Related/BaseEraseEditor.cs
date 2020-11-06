using UnityEngine;

public abstract class BaseEraseEditor : BaseEditor, ILineEditor
{
	public Line CurrentLine { get; set; }
	protected BaseEraseEditor(LineManager lineManager, Camera camera) : base(lineManager, camera) { }

	public void CheckForLine()
	{
		if (!Input.GetMouseButton(0)) return;
		var line = camera.GetComponentAtScreenPosition<Line>(Input.mousePosition);
		if (line == null) return;
		CurrentLine = line;
	}

	public bool StopEditing() => Input.GetMouseButtonUp(0);
	public abstract void UpdateLine();
}