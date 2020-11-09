using UnityEngine;

public static class LineEditorManager
{
    public static Line CurrentLine { get; set; }

    public static void StopEditing()
    {
        if (CurrentLine != null && 
            CurrentLine.PointCount < 2)
            Object.Destroy(CurrentLine.gameObject);
        CurrentLine = null;
    }
}