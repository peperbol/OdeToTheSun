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
        GetComponent<SpriteRenderer>().sprite = color.GetSprite();
        Debug.Log(color.GetSprite());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Activate(){
		activated = true;
	}
	void OnCollisionEnter2D(Collision2D col){
        //Arrive();
	}
    public void Arrive() {
        if (activated)
        {
            Debug.Log("Activated arrive");
            GameProgress.HitBeat();
        }
        else {
            Debug.Log("unactivated arrive");
            GameProgress.MissBeat();
        }
        Destroy(gameObject);
    }
    

}
