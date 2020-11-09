using UnityEngine;

public class EraseSegmentEditor : BaseEraseEditor
{
	protected override void UpdateLine()
	{
		CurrentLine.RemoveSegment(MouseWorldPos);
		CurrentLine = null;
	}
}