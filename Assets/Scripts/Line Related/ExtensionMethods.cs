using UnityEngine;

public static class ExtensionMethods
{
	public static T GetComponentAtScreenPosition<T>(this Camera cam, Vector2 position) where T : Component
	{
		var mousePos = cam.ScreenToWorldPoint(position);
		var hit = Physics2D.OverlapCircle(mousePos, 0.04f);
		return hit != null ? hit.GetComponent<T>() : null;
	}

	public static bool IsBetween(this Vector2 position, Vector2 a, Vector2 b)
		=> position.x.IsBetween(a.x, b.x) && position.y.IsBetween(a.y, b.y);

	private static bool IsBetween(this float original, float a, float b)
		=> Mathf.Abs(a-b) < 0.01f || 
		   a > original && original > b ||
		   a < original && original < b;
	
}