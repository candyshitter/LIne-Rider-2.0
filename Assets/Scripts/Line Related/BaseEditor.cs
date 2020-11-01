using UnityEngine;

public abstract class BaseEditor
{
	protected readonly LineManager lineManager;
	protected readonly Camera camera;
	protected Vector2 MouseWorldPos => camera.ScreenToWorldPoint(Input.mousePosition);

	protected BaseEditor(LineManager lineManager, Camera camera)
	{
		this.lineManager = lineManager;
		this.camera = camera;
	}
}