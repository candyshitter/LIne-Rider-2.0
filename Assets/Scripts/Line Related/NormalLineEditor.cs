using UnityEngine;

public class NormalLineEditor : BaseDrawEditor, ILineEditor
{
	
	public bool StopEditing() => Input.GetMouseButtonUp(0);

	public void UpdateLine() => CurrentLine.UpdateLine(MouseWorldPos);

	public NormalLineEditor(LineManager lineManager, Camera camera) : base(lineManager, camera) { }
}