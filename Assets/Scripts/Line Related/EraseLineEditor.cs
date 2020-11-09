using UnityEngine;

public class EraseLineEditor : BaseEraseEditor
{
	protected override void UpdateLine()
	{
		if (CurrentLine.RemoveLine(MouseWorldPos))
			CurrentLine = null;
	}
}