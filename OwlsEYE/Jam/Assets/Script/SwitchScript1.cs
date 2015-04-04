using UnityEngine;
using System.Collections;

public class SwitchScript1 : MonoBehaviour {
	public GameObject objectToSwitch;
	public GameObject objectToSwitch2;

	public bool isQuestionTheme = false;
	public GameObject textToShow;
	public float CoolDown = 3;//dont need the cooldown, since we dont destroy the object anymore.
	private float timeRemaining;
	private bool launch = false;
	private bool activated = false;

	public Sprite done;
	// Use this for initialization
	void Start () {
		timeRemaining = CoolDown;
		if(textToShow)
			textToShow.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (launch == true && isQuestionTheme == true)
		{
			timeRemaining -= Time.deltaTime;
		}
		
		if (timeRemaining < 0 && isQuestionTheme == true)
		{
			textToShow.SetActive(false);
			objectToSwitch2.GetComponent<MovingPlatformScript>().switchOn();
			gameObject.GetComponent<SpriteRenderer>().sprite = done;
			//			if(launch)
			//				objectToSwitch.GetComponent<MovingPlatformScript>().switchOn();
			//Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D laCollision)
	{
		if (laCollision.tag == "Throwable") {
			if(activated == false)
			{
				if(isQuestionTheme == true)
				{
					textToShow.SetActive(true);
					launch = true;
				}
				objectToSwitch.GetComponent<MovingPlatformScript>().switchOn();
				if(!isQuestionTheme)
					gameObject.GetComponent<SpriteRenderer>().sprite = done;
				activated = true;
			}
		}
	}
}
