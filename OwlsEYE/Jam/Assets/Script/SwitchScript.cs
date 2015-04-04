using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

	public GameObject objectToSwitch;
	public Sprite done;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D laCollision)
	{
		if (laCollision.gameObject.tag == "Throwable") {
			objectToSwitch.GetComponent<MovingPlatformScript>().switchOn();
			gameObject.GetComponent<SpriteRenderer>().sprite = done;
		}
	}

}
