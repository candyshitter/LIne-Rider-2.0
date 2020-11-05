using UnityEngine;

public class LineManager : MonoBehaviour
{
	public static LineManager Instance { get; private set; }
	public Line CurrentLine { get; private set; }
	[SerializeField] private LineEditorType editorType;
	public LineEditorManager LineEditorManager { get; private set; }

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
		Instance.LineEditorManager.CurrentLineEditor.CurrentLine = null;
	}

	private void Awake()
	{
		if (ValidateInstance()) return;
		var mainCamera = Camera.main;
		LineEditorManager = new LineEditorManager();
		LineEditorManager.AddLineEditor(
			LineEditorType.Normal,
			new NormalLineEditor(this, mainCamera));
		LineEditorManager.AddLineEditor(
			LineEditorType.Straight,
			new StraightLineEditor(this, mainCamera));
		LineEditorManager.AddLineEditor(
			LineEditorType.LineErase,
			new EraseLineEditor(this, mainCamera));
		LineEditorManager.AddLineEditor(
			LineEditorType.SegmentErase,
			new EraseSegmentEditor(this, mainCamera));
		LineEditorManager.AddLineEditor(
			LineEditorType.Erase,
			new EraseEditor(this, mainCamera));
		LineEditorManager.AddLineEditor(
			LineEditorType.Move,
			new MoveLineEditor(this, mainCamera));
		LineEditorManager.SetLineCreator(editorType);
	}

	private void Update() => LineEditorManager.Tick();

	public static void SetLinePrefab(Line linePrefab)
	{
		if (linePrefab != null)
			Instance.CurrentLine = linePrefab;
		Instance.LineEditorManager.StopEditing();
	}
}