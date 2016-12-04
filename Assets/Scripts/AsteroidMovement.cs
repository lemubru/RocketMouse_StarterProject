using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

	public int health = 100;
	public FixedJoint[] joints = new FixedJoint[10];
	public int numjoint = 0;
	public GameObject explosion;


	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.tag == "boundary" || other.tag == "firezone") {
			return;
		}
		health = health - 30;
		if (health < 0) {

			GameObject expclone = (GameObject) Instantiate (explosion, transform.position, transform.rotation);

			Destroy (expclone, 1.0f);

			Destroy (gameObject);
		} else {
			Debug.Log (health);
			//Destroy (other.gameObject);
			//FixedJoint joint = gameObject.AddComponent<FixedJoint> ();
			//joint.name = "joint";

			//joint.connectedBody = other.gameObject.GetComponent<Rigidbody> ();
			//joints [numjoint] = joint;
			//numjoint = numjoint + 1;
		}
	}




	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (-44, 0));
	}

	void OnMouseOver() {

		bool press = Input.GetButton ("Fire1");
		if(press){
			//Destroy (gameObject);
			// press you want it to do.
		}
	}




	// Update is called once per frame
	void Update () {
		
	
	}
}
