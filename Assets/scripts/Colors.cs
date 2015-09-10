using UnityEngine;
using System.Collections;

public enum Colors  {
	LIGHTRED = 0, DARKRED = 1, LIGHTPINK = 2, DARKPINK = 3, LIGHTBLUE = 4, DARKBLUE = 5, LIGHTGREEN = 6, DARKGREEN = 7
}

public static class ColorExtantions{

	public static KeyCode GetKey(this Colors c)
	{
		switch (c) {
		case Colors.LIGHTRED:
			return KeyCode.Q;
		case Colors.DARKRED:
			return KeyCode.W;
		case Colors.LIGHTPINK:
			return KeyCode.E;
		case Colors.DARKPINK:
			return KeyCode.R;
		case Colors.LIGHTBLUE:
			return KeyCode.T;
		case Colors.DARKBLUE:
			return KeyCode.Y;
		case Colors.LIGHTGREEN:
			return KeyCode.U;
		case Colors.DARKGREEN:
			return KeyCode.I;
		default:
			return KeyCode.Q;
		}
	}
    public static Sprite GetSprite(this Colors c)
    {
        switch (c)
        {
            case Colors.LIGHTRED:
                return GameObject.FindObjectOfType<ColorSprites>().LightRed;
            case Colors.DARKRED:
                return GameObject.FindObjectOfType<ColorSprites>().DarkRed;
            case Colors.LIGHTPINK:
                return GameObject.FindObjectOfType<ColorSprites>().LightPink;
            case Colors.DARKPINK:
                return GameObject.FindObjectOfType<ColorSprites>().DarkPink;
            case Colors.LIGHTBLUE:
                return GameObject.FindObjectOfType<ColorSprites>().LightBlue;
            case Colors.DARKBLUE:
                return GameObject.FindObjectOfType<ColorSprites>().DarkBlue;
            case Colors.LIGHTGREEN:
                return GameObject.FindObjectOfType<ColorSprites>().LightGreen;
            case Colors.DARKGREEN:
                return GameObject.FindObjectOfType<ColorSprites>().DarkGreen;
            default:
                return null;
        }
    }
}
