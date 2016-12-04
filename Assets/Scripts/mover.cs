using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public float damage;
	void Start () {
		//GetComponent<Rigidbody2D> ().velocity = new Vector2(10, 0)*speed;
	
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "turret" || other.tag == "boundary" || other.tag == "firezone")
			return;
		
		Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
