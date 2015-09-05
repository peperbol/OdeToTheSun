using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	private Colors color;

    public Colors ColorOfNote {
        get { return color; }
        set {  color = value; }
    }
    private bool activated;
	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = color.GetColor();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Activate(){
		activated = true;
	}
	void OnCollisionEnter2D(Collision2D col){
        Arrive();
        Destroy(gameObject);
	}
    private void Arrive() {
        if (activated)
        {
            Debug.Log("Activated arrive");
        }
        else {
            Debug.Log("unactivated arrive");
        }
    }

}
