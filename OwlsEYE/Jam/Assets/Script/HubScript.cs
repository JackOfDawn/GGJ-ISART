using UnityEngine;
using System.Collections;

public class HubScript : MonoBehaviour {

	public GameObject door4;

	void Start () {
		door4 = GameObject.FindGameObjectWithTag("Door4");
		GameObject.FindGameObjectWithTag("Door4").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (PlayerPrefs.GetInt("Lvl2"));
		Debug.Log (PlayerPrefs.GetInt("Lvl3"));
		if (PlayerPrefs.GetInt("Lvl2") == 1){
			GameObject.FindGameObjectWithTag("Door2").SetActive(false);
		}
		if (PlayerPrefs.GetInt("Lvl3") == 1){
			GameObject.FindGameObjectWithTag("Door3").SetActive(false);
		}
		if (PlayerPrefs.GetInt("Lvl2") == 1 && PlayerPrefs.GetInt("Lvl3") == 1){
			door4.SetActive(true);
		}
	}
}
