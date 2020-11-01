using UnityEngine;

public class EraseSegmentEditor : BaseEraseEditor
{
	public EraseSegmentEditor(LineManager lineManager, Camera camera) : base(lineManager, camera) { }

	public override void UpdateLine()
	{
		CurrentLine.RemoveSegment(MouseWorldPos);
		CurrentLine = null;
	}
}