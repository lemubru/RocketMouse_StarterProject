using UnityEngine;
using System.Collections;

public class Barriers : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerEnter(Collider other){
		Debug.Log("Hit barrier");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
