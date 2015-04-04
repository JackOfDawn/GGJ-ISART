using UnityEngine;
using System.Collections;

public class TutoScript : MonoBehaviour {

	public bool leverActivated;
	public GameObject door;

	void Start () {
		door.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (leverActivated == true) {
			door.SetActive (true);
		} else {
			door.SetActive (false);
		}	
	}
}
