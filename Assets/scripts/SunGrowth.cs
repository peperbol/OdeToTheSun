using UnityEngine;
using System.Collections;

public class SunGrowth : MonoBehaviour {
    public VisualFade[] steps = new VisualFade [13];

    [Range(0,1)]
    public float progress;
    private int stepsactivated;
    private int StepsActivated {
        get {
            return stepsactivated; }
        set {

                for (int i = 0; i < steps.Length; i++)
                {
                    steps[i].visible = i <= value;
                }
                stepsactivated = value;
        }
    }
	void Start () {

    }

    void Update()
    {
        StepsActivated = Mathf.FloorToInt(progress * (steps.Length - 1));
    }
}
