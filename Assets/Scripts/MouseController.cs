using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {


	public float jetpackForce = 5.0f;
	public GameObject shot;
	public Transform shotSpawn;
	public GameObject barrier;
	public float nextFire = 0.0f;
	public bool placeMode = false;
	// Use this for initialization
	void Start () {
		
	}




	public void placeModeToggle() {
		if (placeMode == true) {
			placeMode = false;
		} else {
			placeMode = true;
		}
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) 
		{
		     // we want 2m away from the camera position
			Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//Debug.Log (worldMousePos.x);
			//Debug.Log (worldMousePos.y);
			if (placeMode == true) {
				worldMousePos.z = 0.0f;
				GameObject expclone = (GameObject) Instantiate (barrier, worldMousePos, Quaternion.identity);
				if(worldMousePos.y < -3.5 && worldMousePos.x < -5.0)
					Destroy (expclone);

				Destroy (expclone,3.0f);
			}
		}
	}

	void FixedUpdate()
	{
		bool jetpackActive = Input.GetButton ("Fire1");
		if (jetpackActive && Time.time >= nextFire) {
			nextFire = Time.time + 0.1f;
			GameObject shotclone = (GameObject) Instantiate (shot, shotSpawn.position, shotSpawn.rotation);

			Physics2D.IgnoreCollision(shotclone.GetComponent<Collider2D>(), GetComponent<Collider2D>());

			Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 direction = (Vector2)((worldMousePos - shotSpawn.position));
			direction.Normalize ();
			shotclone.GetComponent<Rigidbody2D> ().velocity = direction * 12;


			shotclone.GetComponent<Rigidbody2D> ().angularVelocity = 0.0f;
			worldMousePos.x = worldMousePos.x - shotSpawn.position.x;
			worldMousePos.y = worldMousePos.y -  shotSpawn.position.y;
			float angle = Mathf.Atan2(worldMousePos.y, worldMousePos.x) * Mathf.Rad2Deg;
			shotclone.transform.eulerAngles= new Vector3(0, 0, angle);
			Destroy (shotclone,3.0f);
		} else if (jetpackActive){
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 44));



		} 
	}

}
