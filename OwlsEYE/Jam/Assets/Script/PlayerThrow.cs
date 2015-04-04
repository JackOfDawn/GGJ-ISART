using UnityEngine;
using System.Collections;

public class PlayerThrow : MonoBehaviour {

	// Use this for initialization
	public bool slingshot;
	public GameObject throwable;
	public GameObject lightThrowable;
	public int xOffset = 1;
	public float MAX_COOLDOWN = 1;
	private float cooldown;
	//private Vector3 offset;
	void Start () {
		//offset = new Vector3 (xOffset, 0 , 0);
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		//if throw button is press, create throwable with velocity in player's direction?
		if (Input.GetKey (KeyCode.JoystickButton5) && cooldown <= 0 && gameObject.GetComponent<Player> ().objectID == 11) {
			CreateThrowable();
			cooldown = MAX_COOLDOWN;
			AudioSource.PlayClipAtPoint(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundManagerScript>().Tir, transform.position);
		}
		if (Input.GetKey (KeyCode.JoystickButton5) && cooldown <= 0 && gameObject.GetComponent<Player> ().objectID == 14) {
			CreateLightThrowable();
			cooldown = MAX_COOLDOWN;
			AudioSource.PlayClipAtPoint(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundManagerScript>().Tir, transform.position);
		}
	}

	void CreateThrowable()	{
		Move playerMove = gameObject.GetComponent<Move>();
		if (playerMove) {
			Instantiate (throwable, transform.position, gameObject.transform.rotation);
		}
	}

	void CreateLightThrowable()	{
		Move playerMove = gameObject.GetComponent<Move>();
		if (playerMove) {
			Instantiate (lightThrowable, transform.position, gameObject.transform.rotation);
		}
	}
}
