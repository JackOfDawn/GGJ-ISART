using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {
	
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
