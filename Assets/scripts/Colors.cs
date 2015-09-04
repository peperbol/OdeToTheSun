using UnityEngine;
using System.Collections;

public enum Colors  {
	DARKBLUE = 0, GREEN = 1, RED = 2, PURPLE = 3, ORANGE = 4, YELLOW = 5, BLACK = 6, CYAN = 7
}
public static class ColorExtantions{

	public static KeyCode GetKey(this Colors c)
	{
		switch (c) {
		case Colors.DARKBLUE:
			return KeyCode.Q;
		case Colors.GREEN:
			return KeyCode.W;
		case Colors.RED:
			return KeyCode.E;
		case Colors.PURPLE:
			return KeyCode.R;
		case Colors.ORANGE:
			return KeyCode.T;
		case Colors.YELLOW:
			return KeyCode.Y;
		case Colors.BLACK:
			return KeyCode.U;
		case Colors.CYAN:
			return KeyCode.I;
		default:
			return KeyCode.Q;
		}
	}
}
