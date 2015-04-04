using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public string levelToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D Door){
		if (Door.gameObject.tag == "Player") {
			if(Application.loadedLevelName == "Lvl2"){
				PlayerPrefs.SetInt("Lvl2", 1);
			}
			if(Application.loadedLevelName == "Lvl3"){
				PlayerPrefs.SetInt("Lvl3", 1);
			}
			Application.LoadLevel(levelToLoad);
		}
	}
}
