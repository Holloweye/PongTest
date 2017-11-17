using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Extensions
{
	public static float distance(this Vector2 self, Vector2 pos)
	{
		return Mathf.Abs (Mathf.Sqrt (Mathf.Pow (pos.x - self.x, 2) + Mathf.Pow (pos.y - self.y, 2)));
	}

	public static float angle(this Vector2 self, Vector2 pos)
	{
		return Mathf.Atan2(pos.y - self.y, pos.x - self.x);
	}

	public static Vector2 bearing(this Vector2 self, Vector2 pos)
	{
		float a = self.angle (pos);
		return new Vector2 (Mathf.Cos (a), Mathf.Sin (a));
	}

	public static Vector2 multiply(this Vector2 self, double value)
	{
		return new Vector2 (self.x * (float)value, self.y * (float)value);
	}

	public static Vector2 add(this Vector2 self, Vector2 value)
	{
		return new Vector2 (self.x + value.x, self.y + value.y);
	}
}

public static class FloatExtensions
{
	public static Vector2 bearing(this float angle)
	{
		return new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle));
	}

	public static float degrees(this float self)
	{
		return self * (float)180.0 / Mathf.PI;
	}

	public static float radians(this float self)
	{
		return self * Mathf.PI / (float)180.0;
	}
}

public static class CameraExtensions
{
	public static Vector2 mousePosition(this Camera self)
	{
		return self.ScreenToWorldPoint (Input.mousePosition);
	}
}

public static class GameObjectExtensions
{
	public static void setCollision(this GameObject self, GameObject other, bool collide)
	{
		var sc = self.GetComponent<Collider2D>();
		var oc = other.GetComponent<Collider2D> ();

		if (sc != null && oc != null) {
			Physics2D.IgnoreCollision (sc, oc, !collide);
		}
	}
}
	