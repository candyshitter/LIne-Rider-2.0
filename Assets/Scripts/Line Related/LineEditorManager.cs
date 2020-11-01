using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class LineEditorManager
{
	public ILineEditor CurrentLineEditor { get; private set; }
	private readonly Dictionary<LineEditorType, ILineEditor> _lineCreators = new Dictionary<LineEditorType, ILineEditor>();

	private event Action<LineEditorType> OnEditorChanged =
		editorType => Debug.Log($"Changed to {editorType}");

	private ILineEditor GetLineEditor(LineEditorType lineEditorType) =>
		!_lineCreators.ContainsKey(lineEditorType) ? null : _lineCreators[lineEditorType];

	public void AddLineEditor(LineEditorType lineEditorType, ILineEditor lineEditor) =>
		_lineCreators[lineEditorType] = lineEditor;

	public void SetLineCreator(LineEditorType lineEditorType)
	{
		var lineEditor = GetLineEditor(lineEditorType);
		if(lineEditor == null || lineEditor == CurrentLineEditor) return;
		if (CurrentLineEditor != null)
			CurrentLineEditor.CurrentLine = null;
		CurrentLineEditor = lineEditor;
		OnEditorChanged.Invoke(lineEditorType);
	}

	public void Tick()
	{
		CurrentLineEditor.CheckForLine();
		if(CurrentLineEditor.CurrentLine == null) return;
		if (CurrentLineEditor.StopEditing())
		{
			if (CurrentLineEditor.CurrentLine.PointCount < 2)
				Object.Destroy(CurrentLineEditor.CurrentLine.gameObject);
			CurrentLineEditor.CurrentLine = null;
			return;
		}
		CurrentLineEditor.UpdateLine();
	}
}

public enum LineEditorType
{
	Normal,
	Straight,
	LineErase,
	SegmentErase,
	Erase,
	Move
}