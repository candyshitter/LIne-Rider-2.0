using UnityEngine;
public class StraightLineEditor : BaseDrawEditor
{
	protected override bool StopEditing() => Input.GetMouseButtonDown(1);

	protected override bool CanDraw => base.CanDraw && CurrentLine == null;

	protected override void UpdateLine()
	{
		if(base.CanDraw && CurrentLine != null)
			CurrentLine.UpdateLine(MouseWorldPos);
	}
}