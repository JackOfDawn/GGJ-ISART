using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public int objectID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (objectID == 5) {
			transform.GetChild (1).gameObject.SetActive (true);
		} else {
			transform.GetChild (1).gameObject.SetActive (false);
		}

	}
}
