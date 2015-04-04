using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamiteScript : MonoBehaviour {
	
	public float timer;
	public Text timeLeft;
	public bool dynamite;

	void Start () {
		
	}

	void Update () {
		if (dynamite == true) {
			timer -= Time.deltaTime;
			timeLeft.text = "" + (int)Mathf.Round (timer);
			if (timer < 0) {
					StartCoroutine ("Loose");
			}
		} else {
			timeLeft.text = "";
		}
	}

	IEnumerator Loose(){
		timeLeft.text = "You loose";
		yield return new WaitForSeconds (2);
		Application.LoadLevel (Application.loadedLevel);
	}
}
