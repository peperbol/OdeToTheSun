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
    public static Color GetColor(this Colors c)
    {
        switch (c)
        {
            case Colors.DARKBLUE:
                return Color.blue;
            case Colors.GREEN:
                return Color.green;
            case Colors.RED:
                return Color.red;
            case Colors.PURPLE:
                return new Color(0.5f, 0f, 0.5f);
            case Colors.ORANGE:
                return new Color(1f,0.5f,0f);
            case Colors.YELLOW:
                return Color.yellow;
            case Colors.BLACK:
                return Color.black;
            case Colors.CYAN:
                return Color.cyan;
            default:
                return Color.white;
        }
    }
}
