using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class EditorManager
{
	public ILineEditor CurrentLineEditor { get; private set; }
	public Line CurrentLine { get; set; }

	private readonly Dictionary<LineEditorType, ILineEditor> _lineCreators = new Dictionary<LineEditorType, ILineEditor>();

	private ILineEditor GetLineEditor(LineEditorType lineEditorType) =>
		!_lineCreators.ContainsKey(lineEditorType) ? null : _lineCreators[lineEditorType];

	public void AddLineEditor(LineEditorType lineEditorType, ILineEditor lineEditor) =>
		_lineCreators[lineEditorType] = lineEditor;

	public void SetLineCreator(LineEditorType lineEditorType)
	{
		var lineEditor = GetLineEditor(lineEditorType);
		if(lineEditor == null || lineEditor == CurrentLineEditor) return;
		if (CurrentLineEditor != null)
			CurrentLine = null;
		CurrentLineEditor = lineEditor;
		Debug.Log($"Changed to {lineEditorType}");
	}

	public void Tick() => CurrentLineEditor.Tick();
}

public enum LineEditorType
{
	Normal,
	Straight,
	LineErase,
	SegmentErase,
	Erase,
	Move,
	Pan,
	Zoom
}