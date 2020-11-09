using UnityEngine;

public class EraseEditor : BaseEraseEditor
{

	protected override void UpdateLine()
	{
		Object.Destroy(CurrentLine.gameObject);
		CurrentLine = null;
	}
}