using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour
{
	[SerializeField] protected List<Vector2> points = new List<Vector2>();
	private LineRenderer _lineRenderer;
	private EdgeCollider2D _collider;

	public int PointCount => points.Count;
	private int EndIndex => points.Count - 1;

	private void Awake()
	{
		_lineRenderer = GetComponent<LineRenderer>();
		_collider = GetComponent<EdgeCollider2D>();
	}

	private bool TooFewPoints(int max = 1)
	{
		if (points.Count > max) return false;
		Destroy(gameObject);
		return true;
	}

	public void UpdateLine(Vector2 segment)
	{
		if (points.Count == 0 || Vector2.Distance(points[EndIndex], segment) > .04f)
			AddSegment(segment);
	}

	private void AddSegment(Vector2 point)
	{
		points.Add(point);
		_lineRenderer.positionCount = points.Count;
		_lineRenderer.SetPosition(EndIndex, point);
		if (points.Count < 2) return;
		_collider.points = points.ToArray();
	}

	public void RemoveSegment(Vector2 mousePos)
	{
		var index = GetIndexCloseTo(mousePos);
		if (index == -1) return;

		if (index == EndIndex)
			RemoveEnd();
		else if (index == EndIndex - 1)
			RemoveEnd(2);
		else switch (index)
		{
			case 0: RemoveFirst();
				break;
			case 1: RemoveFirst(2);
				break;
			default: RemoveAtIndex(index);
				break;
		}
	}

	public bool RemoveLine(Vector2 mousePos)
	{
		var second = GetLineBetween(mousePos);
		if (second < 0) return false;

		if(second - 1 == 0)
			RemoveFirst();
		else if(second == EndIndex)
			RemoveEnd();
		else
			RemoveLineAtIndex(second);

		return true;
	}

	private int GetLineBetween(Vector2 mousePos)
	{
		for (var i = 1; i < points.Count; i++)
			if (mousePos.IsBetween(points[i - 1], points[i]))
				return  i;
		return -1;
	}

	private int GetIndexCloseTo(Vector2 mousePos)
	{
		for (var i = 0; i < points.Count; i++)
		{
			var distance = Vector2.Distance(mousePos, points[i]);
			if (!(distance < 0.04f)) continue;
			return i;
		}
		return -1;
	}

	private void UpdateSegments()
	{
		SetLinePoints();
		for (var i = 0; i < points.Count; i++)
			_lineRenderer.SetPosition(i, points[i]);
	}

	private void SetLinePoints()
	{
		_lineRenderer.positionCount = points.Count;
		_collider.points = points.ToArray();
	}

	private void RemoveRange(int index, int count)
	{
		if (RemoveRangeNoUpdate(index, count))
			UpdateSegments();
	}

	private bool RemoveRangeNoUpdate(int index, int count)
	{
		points.RemoveRange(index, count);
		return !TooFewPoints();
	}

	private void RemoveWithIndex(int index, int offset)
	{
		var newLine = Instantiate(this);
		RemoveRange(index, points.Count - index);
		newLine.RemoveRange(0, index + offset);
	}

	private void RemoveLineAtIndex(int index) => RemoveWithIndex(index, 0);

	private void RemoveAtIndex(int index) => RemoveWithIndex(index, 1);

	private void RemoveFirst(int count = 1) => RemoveRange(0, count);

	private void RemoveEnd(int count = 1)
	{
		if (RemoveRangeNoUpdate(points.Count - count, count))
			SetLinePoints();
	}
}