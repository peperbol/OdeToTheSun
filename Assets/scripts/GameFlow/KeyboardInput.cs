using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour
{

    void Update()
    {

        for (int i = 0; i < GameProperties.NUMBER_OF_COLORS; i++)
        {
            InputController.SetPress((SolarColor)i, Input.GetKey( ((SolarColor)i).GetKey() ));
        }
    }
}
