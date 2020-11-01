using UnityEngine;

public class EraseEditor : BaseEraseEditor
{
	public EraseEditor(LineManager lineManager, Camera camera) : base(lineManager, camera) { }

	public override void UpdateLine()
	{
		Object.Destroy(CurrentLine.gameObject);
		CurrentLine = null;
	}
}