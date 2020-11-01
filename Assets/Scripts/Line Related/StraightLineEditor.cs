using UnityEngine;
public class StraightLineEditor : BaseDrawEditor, ILineEditor
{
	public StraightLineEditor(LineManager lineManager, Camera camera) : base(lineManager, camera) { }

	public bool StopEditing() => Input.GetMouseButtonDown(1);

	protected override bool CanDraw => base.CanDraw && CurrentLine == null;

	public void UpdateLine()
	{
		if(base.CanDraw && CurrentLine != null)
			CurrentLine.UpdateLine(MouseWorldPos);
	}
}