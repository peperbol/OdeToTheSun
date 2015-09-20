using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour {

	public Vector3 target;
    public bool turnToLeft = true;
	void Start(){
    }
	
	// Update is called once per frame
	void Update ()
    {

        transform.LookAt(target);

        Vector2 direction = target - transform.position;
        float rotspeed = direction.magnitude* Mathf.PI / 180 * GameProperties.NoteRotation;
        
        Vector2 forward = direction.normalized;
        float aAngle = Mathf.Atan(forward.x / forward.y) + Mathf.PI / 2;
        Vector2 aside = new Vector2(((forward.y > 0) ? 1 : -1) * Mathf.Sin(aAngle), ((forward.y > 0) ? 1 : -1) * Mathf.Cos(aAngle));
        transform.position +=  (Vector3)forward * GameProperties.NoteVelocity * Time.deltaTime;
        transform.position += (Vector3)aside * rotspeed * Time.deltaTime * ((turnToLeft)? -1 :1);
    }
    /*
    // Debug gizmo draw (directions)
    void OnDrawGizmos() {

        Vector2 direction = target - transform.position;
        float rotspeed = direction.magnitude * Mathf.PI / 180 * GameProperties.NoteRotation;

        //   direction = target - transform.position;
        // direction.Normalize();
        Debug.Log(direction.magnitude + " " + rotspeed);
        Vector2 forward = direction.normalized;
        float aAngle = Mathf.Atan(forward.x / forward.y) + Mathf.PI/2;
        Vector2 aside = new Vector2( ((forward.y >0 )?1:-1)*Mathf.Sin(aAngle), ((forward.y > 0) ? 1 : -1) * Mathf.Cos(aAngle));

        Gizmos.color = new Color(0.4f, 0.6f, 0.2f);
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)forward);
        Gizmos.color = new Color(0.7f, 0.2f, 0.4f);
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)aside);
    }
    */
}
