using UnityEngine;
using System.Collections;

public class ObjetScript : MonoBehaviour {

	private bool detected = false;
	public int ID;
	
	// Update is called once per frame
	void Update () {
	
		if (detected == true) {
			gameObject.renderer.material.color = new Color (1, 0, 0, 1); // Just a FeedBack that we can use this object
			if (Input.GetKey (KeyCode.Space)) {
				Destroy(gameObject); // Put choice of what action we wanna do
				GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().objectID = ID;
			}
		} else {
			gameObject.renderer.material.color = new Color (1, 1, 1, 1); // Just remove the FeedBack
		}
	}

	void OnTriggerEnter2D (Collider2D Detection){
		if (Detection.gameObject.tag == "PlayerDetection"){
			detected = true;
		}
	}

	void OnTriggerExit2D (Collider2D Detection){
		if (Detection.gameObject.tag == "PlayerDetection"){
			detected = false;
		}
	}
}
