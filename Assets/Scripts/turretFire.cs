using UnityEngine;
using System.Collections;

public class turretFire : MonoBehaviour {

	public bool spin = false;

	public bool triggered = false;
	Collider2D other;
	public GameObject shot;
	public Transform shotSpawn;
	public float nextFire = 0.0f;
	public float fireInterval = 0.5f;
	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision(transform.parent.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "coin") {
			Debug.Log ("yay" + System.DateTime.Now);
			spin = true;
			triggered = true;
			this.other = other;

		}
	
	}


	void OnTriggerStay2D(Collider2D other){
		
		if (spin && Time.time >= nextFire && other.tag == "coin") {


			transform.parent.LookAt(other.transform);
			nextFire = Time.time + fireInterval;
			GameObject shotclone = (GameObject)Instantiate (shot, shotSpawn.position, shotSpawn.rotation);

			Physics2D.IgnoreCollision (shotclone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());

			Vector3 worldMousePos = other.transform.position;
			Vector2 direction = (Vector2)((worldMousePos - shotSpawn.position));
			direction.Normalize ();
			shotclone.GetComponent<Rigidbody2D> ().velocity = direction * 12;


			shotclone.GetComponent<Rigidbody2D> ().angularVelocity = 0.0f;
			worldMousePos.x = worldMousePos.x - shotSpawn.position.x;
			worldMousePos.y = worldMousePos.y - shotSpawn.position.y;
			float angle = Mathf.Atan2 (worldMousePos.y, worldMousePos.x) * Mathf.Rad2Deg;

			shotclone.transform.eulerAngles= new Vector3(0, 0, angle);

			Destroy (shotclone, 4.0f);



			Vector3 diff = worldMousePos - shotSpawn.position;
			diff.Normalize();

			float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
			transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "turret") {
			return;
		}
		//spin = false;
	}



	void Update () {
		if ( triggered && !other )
		{
			spin = false;
			// put exit trigger logic here
		}
	}

	void FixedUpdate () {

	

	}
}
