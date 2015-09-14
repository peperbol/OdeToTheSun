using UnityEngine;
using System.Collections;

public enum SolarColor  {
	LIGHTRED = 0, DARKRED = 1, LIGHTPINK = 2, DARKPINK = 3, LIGHTBLUE = 4, DARKBLUE = 5, LIGHTGREEN = 6, DARKGREEN = 7
}

public static class ColorExtentions{

	public static KeyCode GetKey(this SolarColor c)
	{
		switch (c) {
		case SolarColor.LIGHTRED:
			return KeyCode.Q;
		case SolarColor.DARKRED:
			return KeyCode.W;
		case SolarColor.LIGHTPINK:
			return KeyCode.E;
		case SolarColor.DARKPINK:
			return KeyCode.R;
		case SolarColor.LIGHTBLUE:
			return KeyCode.T;
		case SolarColor.DARKBLUE:
			return KeyCode.Y;
		case SolarColor.LIGHTGREEN:
			return KeyCode.U;
		case SolarColor.DARKGREEN:
			return KeyCode.I;
		default:
			return KeyCode.Q;
		}
	}
    public static Sprite GetSprite(this SolarColor c)
    {
        switch (c)
        {
            case SolarColor.LIGHTRED:
                return GameObject.FindObjectOfType<ColorSprites>().LightRed;
            case SolarColor.DARKRED:
                return GameObject.FindObjectOfType<ColorSprites>().DarkRed;
            case SolarColor.LIGHTPINK:
                return GameObject.FindObjectOfType<ColorSprites>().LightPink;
            case SolarColor.DARKPINK:
                return GameObject.FindObjectOfType<ColorSprites>().DarkPink;
            case SolarColor.LIGHTBLUE:
                return GameObject.FindObjectOfType<ColorSprites>().LightBlue;
            case SolarColor.DARKBLUE:
                return GameObject.FindObjectOfType<ColorSprites>().DarkBlue;
            case SolarColor.LIGHTGREEN:
                return GameObject.FindObjectOfType<ColorSprites>().LightGreen;
            case SolarColor.DARKGREEN:
                return GameObject.FindObjectOfType<ColorSprites>().DarkGreen;
            default:
                return null;
        }
    }
  public static Color GetColor(this SolarColor c)
  {
    switch (c)
    {
      case SolarColor.LIGHTRED:
        return new Color(1f,0f,0f);
      case SolarColor.DARKRED:
        return new Color(0.6f, 0f, 0f);
      case SolarColor.LIGHTPINK:
        return new Color(1f, 0f, 0.9f);
      case SolarColor.DARKPINK:
        return new Color(0.45f, 0f, 0.75f);
      case SolarColor.LIGHTBLUE:
        return new Color(0.2f, 0.7f, 0.9f);
      case SolarColor.DARKBLUE:
        return new Color(0f, 0.2f, 0.7f);
      case SolarColor.LIGHTGREEN:
        return new Color(0.2f, 1f, 0.1f);
      case SolarColor.DARKGREEN:
        return new Color(0.1f, 0.3f, 0f);
      default:
        return new Color(0f, 0f, 0f);
    }
  }
}
