using UnityEngine;
using System.Collections;

public class GroundDetectionScript : MonoBehaviour {

	public bool grounded;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D thisCollision) {
		if (thisCollision.gameObject.tag == "Ground") {
			grounded = true;
		}
	}
	void OnTriggerStay2D(Collider2D thisCollision) {
		if (thisCollision.gameObject.tag == "Ground") {
			grounded = true;
		}
	}
	void OnTriggerExit2D(Collider2D thisCollision) {
		if (thisCollision.gameObject.tag == "Ground") {
			grounded = false;
		}
	}
}
