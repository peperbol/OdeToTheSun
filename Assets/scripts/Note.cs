using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	private Colors color;
    public AudioClip miss;
    public AudioClip hit;
    public AudioPlay src;
    public Colors ColorOfNote {
        get { return color; }
        set {  color = value; }
    }
    private bool activated;
	// Use this for initialization
	void Start () {
        GetComponentInChildren<SpriteRenderer>().sprite = color.GetSprite();
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
    public void Validate()
    {
        Debug.Log("val");
        if (activated)
        {
            Debug.Log("Activated arrive");
            GameProgress.HitBeat();
            AudioPlay.PlaySound(hit, src);
        }
        else
        {
            Debug.Log("unactivated arrive");
            GameProgress.MissBeat();
            AudioPlay.PlaySound(miss, src);
        }
        Destroy(gameObject);
    }
    public void Arrive() {
        Debug.Log("arr");
        Destroy( GetComponent<Renderer>());
    }
    

}
