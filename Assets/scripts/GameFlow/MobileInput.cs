using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobileInput : MonoBehaviour
{
    protected Collider2D[] buttons;
    public Collider2D buttonPrefab;
    public float buttonDistance;

    void Start()
    {
        Vector3[] poss = CalculateInputPosition(4);
        buttons = new Collider2D[poss.Length];
        for (int i = 0; i < poss.Length; i++)
        {
            buttons[i] = Instantiate(buttonPrefab);
            buttons[i].transform.SetParent(transform);
            buttons[i].transform.localPosition = poss[i];
            buttons[i].GetComponentInChildren<SpriteRenderer>().color = ((SolarColor)i).GetColor();
        }
    }

    void Update()
    {

        for (int i = 0, l = buttons.Length; i < l; i++)
        {
            Touch[] touches = Input.touches;
            bool press = false;
            for (int j = 0; j < touches.Length; j++)
            {
                press |= buttons[i].OverlapPoint(Camera.main.ScreenPointToRay(touches[j].position).origin);
                if (press) break;
            }
            InputController.SetPress((SolarColor)i, press);
        }
    }
    
    protected Vector3[] CalculateInputPosition(int playersCount)
    {
        Vector3[] result;
        switch (playersCount)
        {
            case 4: // radial
                result = new Vector3[GameProperties.NUMBER_OF_COLORS];
                for (int i = 0; i < playersCount; i++)
                {
                    float angle_to_player = 2 * Mathf.PI / playersCount * i;

                    result[i*2] = new Vector3(
                            Mathf.Cos(angle_to_player - GameProperties.ANGLE_OFFSET_BETWEEN_HANDS) * buttonDistance,
                            Mathf.Sin(angle_to_player - GameProperties.ANGLE_OFFSET_BETWEEN_HANDS) * buttonDistance,
                            0
                        );
                    result[i*2+1] = new Vector3(
                            Mathf.Cos(angle_to_player + GameProperties.ANGLE_OFFSET_BETWEEN_HANDS) * buttonDistance,
                            Mathf.Sin(angle_to_player + GameProperties.ANGLE_OFFSET_BETWEEN_HANDS) * buttonDistance,
                            0
                        );
                }
                break;
            default:
                result = new Vector3[0];
                break;
        }
        return result;
    }
}
