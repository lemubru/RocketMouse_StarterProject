using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject coin;
	public Vector3 spawnValue;
	public float spawnWait;


	IEnumerator SpawnCoins(){
		yield return new WaitForSeconds (2);
		for (int j = 0; j < 50; j = j + 1) {
			for (int i = 0; i < 2; i = i + 1) {
				Vector3 spawnPos = new Vector3 (Random.Range (11, 14), Random.Range (-2, 5), 0);
				Instantiate (coin, spawnPos, transform.rotation);
			}
			yield return new WaitForSeconds (2);
		}
	}
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 70;
		StartCoroutine (
		SpawnCoins ()
		);
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
