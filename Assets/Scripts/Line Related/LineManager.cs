using System;
using UnityEngine;

public class LineManager : MonoBehaviour
{
	public static LineManager Instance { get; private set; }
	[SerializeField] private LineEditorType editorType;
	public Camera Camera { get; private set; }
	public static Line CurrentLine { get; private set; }
	public EditorManager EditorManager { get; private set; }

	private bool ValidateInstance()
	{
		if (Instance == null)
			Instance = this;
		else
		{
			Destroy(gameObject);
			return true;
		}
		return false;
	}

	public static void DestroyLines()
	{
		foreach (var line in FindObjectsOfType<Line>())
			Destroy(line.gameObject);
		Instance.EditorManager.CurrentLine = null;
	}

	private void Awake()
	{
		if (ValidateInstance()) return;
		Camera = Camera.main;
		EditorManager = new EditorManager();
		EditorManager.AddLineEditor(
			LineEditorType.Normal,
			new NormalLineEditor());
		EditorManager.AddLineEditor(
			LineEditorType.Straight,
			new StraightLineEditor());
		EditorManager.AddLineEditor(
			LineEditorType.LineErase,
			new EraseLineEditor());
		EditorManager.AddLineEditor(
			LineEditorType.SegmentErase,
			new EraseSegmentEditor());
		EditorManager.AddLineEditor(
			LineEditorType.Erase,
			new EraseEditor());
		EditorManager.AddLineEditor(
			LineEditorType.Move,
			new MoveLineEditor());
		EditorManager.AddLineEditor(
			LineEditorType.Pan,
			new PanEditor());
		EditorManager.AddLineEditor(
			LineEditorType.Zoom,
			new ZoomEditor());
		EditorManager.SetLineCreator(editorType);
	}

	private void Update() => EditorManager.Tick();

	public static void SetLinePrefab(Line linePrefab)
	{
		if (linePrefab != null)
			CurrentLine = linePrefab;
		LineEditorManager.StopEditing();
	}
}