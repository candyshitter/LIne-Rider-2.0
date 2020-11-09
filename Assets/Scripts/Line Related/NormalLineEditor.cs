using UnityEngine;

public class NormalLineEditor : BaseDrawEditor
{
	protected override bool StopEditing() => Input.GetMouseButtonUp(0);

	protected override void UpdateLine() => CurrentLine.UpdateLine(MouseWorldPos);

}