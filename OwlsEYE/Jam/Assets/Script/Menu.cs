using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Texture backgroundSplash;
	public string levelToLoad;

	void OnGUI()
	{

	}

	void Update()
	{
		bool startPressed = Input.GetAxis ("Submit") > 0 || Input.GetKey(KeyCode.JoystickButton7);

		if (startPressed) {
			PlayerPrefs.SetInt ("Lvl2", 0);
			PlayerPrefs.SetInt ("Lvl3", 0);
			Application.LoadLevel (levelToLoad);
		}
	}
}
