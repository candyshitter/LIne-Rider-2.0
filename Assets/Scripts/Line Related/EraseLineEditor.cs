using UnityEngine;

public class EraseLineEditor : BaseEraseEditor
{
	public EraseLineEditor(LineManager lineManager, Camera camera) : base(lineManager, camera) { }

	public override void UpdateLine()
	{
		if (CurrentLine.RemoveLine(MouseWorldPos))
			CurrentLine = null;
	}
}