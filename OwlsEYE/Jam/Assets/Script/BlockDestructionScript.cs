using UnityEngine;
using System.Collections;

public class BlockDestructionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D laCollision) {

		if (laCollision.collider.tag == "LightThrowable") {
			Destroy(laCollision.collider.gameObject);
			Destroy (gameObject);
		
		}
	
	}
}
