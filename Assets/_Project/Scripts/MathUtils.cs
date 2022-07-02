using UnityEngine;

namespace EpicGameJam
{
	public static class MathUtils
	{
		public static bool IsApproxZero(this Vector2 vec)
		{
			return Mathf.Approximately(vec.x, 0) && Mathf.Approximately(vec.y, 0);
		}
	}
}