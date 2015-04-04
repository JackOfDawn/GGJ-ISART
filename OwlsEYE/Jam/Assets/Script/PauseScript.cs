using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public bool paused = false;
	float lastRealTimeUpdate;
	float pauseDeltaTime;
	bool lastStartDown;

	void Start()
	{
		lastRealTimeUpdate = Time.realtimeSinceStartup;
	}


	void Update()
	{
		pauseDeltaTime = Time.realtimeSinceStartup - lastRealTimeUpdate;

		bool startDown = Input.GetKey (KeyCode.JoystickButton7);

		if (startDown && !lastStartDown && !paused) {
			paused = true;
			Time.timeScale = 0.0f;
			GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
		} else if (startDown && !lastStartDown && paused){
			paused = false;
			Time.timeScale = 1;
			GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = true;
		}

		if (paused) {
			OnPause();
		} else {

		}
		lastStartDown = startDown;
	}

	void OnPause()
	{

	}
}
