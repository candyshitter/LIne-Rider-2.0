using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public abstract class BaseEditor : ILineEditor
{
    protected readonly Camera camera;
    protected Vector2 MouseWorldPos => camera.ScreenToWorldPoint(Input.mousePosition);

    protected static Line CurrentLine
    {
        get => LineEditorManager.CurrentLine;
        set => LineEditorManager.CurrentLine = value;
    }

    protected BaseEditor() => camera = LineManager.Instance.Camera;

    public void Tick()
    {
        CheckForLine();
        if (CurrentLine == null) return;
        if (StopEditing())
        {
            LineEditorManager.StopEditing();
            return;
        }
        UpdateLine();
    }

    protected abstract void CheckForLine();
    protected abstract bool StopEditing();
    protected abstract void UpdateLine();
}