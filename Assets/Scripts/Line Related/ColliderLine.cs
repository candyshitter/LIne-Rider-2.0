using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class ColliderLine : Line
{
	private EdgeCollider2D _collider;
	protected override void Awake()
	{
		base.Awake();
		_collider = GetComponent<EdgeCollider2D>();
	}

	protected override void AddSegment(Vector2 point)
	{
		base.AddSegment(point);
		if (points.Count < 2) return;
		_collider.points = points.ToArray();
	}

	protected override void SetLinePoints()
	{
		base.SetLinePoints();
		_collider.points = points.ToArray();
	}
}