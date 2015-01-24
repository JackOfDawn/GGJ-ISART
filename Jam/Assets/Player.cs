using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float vitesse = 5.0f;
	public int objectID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * vitesse * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * vitesse * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.up * vitesse * Time.deltaTime);
		}

	}
}
