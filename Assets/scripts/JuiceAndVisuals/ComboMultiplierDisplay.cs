using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ComboMultiplierDisplay : MonoBehaviour
{
    private Text text;
    public string prefix;
    public string suffix;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (GameProperties.Playing)? prefix + GameProgress.ComboMultiplier.ToString("0.00") + suffix : "";
    }
}
