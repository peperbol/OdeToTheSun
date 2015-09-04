using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveTowards : MonoBehaviour {

	public Vector3 target;

	void Start(){
		Vector2 direction =  target- transform.position ;
		direction.Normalize ();
		GetComponent<Rigidbody2D> ().velocity = direction * GameProperties.NoteVelocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
