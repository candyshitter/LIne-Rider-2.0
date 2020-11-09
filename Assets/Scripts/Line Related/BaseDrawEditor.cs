using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseDrawEditor : BaseEditor
{
	protected virtual bool CanDraw => Input.GetMouseButtonDown(0) && ValidMousePos();

	protected override void CheckForLine()
	{
		if (CanDraw)
			CurrentLine = Object.Instantiate(LineManager.CurrentLine);
	}

	private static bool ValidMousePos()
	{
		var results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(
			new PointerEventData(EventSystem.current) {position = Input.mousePosition},
			results);
		return !(results.Count > 0);
	}
}