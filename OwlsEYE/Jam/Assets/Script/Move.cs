using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public int walkSpeed = 10;
	public int runSpeed = 20;
	public int speed = 0;
	public int jumpPower = 5;
	public bool isFacingRight = true;
	public int direction = 1;
	public bool grounded;
	public float yValue;
	public float xValue;
	public Sprite idle;

	public GameObject target;

	public AudioClip walkSnow;
	public AudioClip walkCave;
	public AudioClip walkHub;
	private bool walk;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		grounded = transform.GetChild (2).GetComponent<GroundDetectionScript> ().grounded;

		xValue = Input.GetAxis ("Horizontal");

		if (grounded && xValue != 0 && walk == false) {
			if (Application.loadedLevelName == "HUB" || Application.loadedLevelName == "Tuto"){
				audio.PlayOneShot (walkHub);
			}
			if (Application.loadedLevelName == "Lvl2" || Application.loadedLevelName == "Lvl4"){
				audio.PlayOneShot (walkCave);
			}
			if (Application.loadedLevelName == "Lvl3"){
				audio.PlayOneShot (walkSnow);
			}
			walk = true;
		} else if (grounded == false || xValue == 0){
			audio.Stop();
			walk = false;
		}

		if (xValue < 0 && isFacingRight) {
			FlipSprite();
			direction = -1;
		}
		if (xValue > 0 && !isFacingRight) {
			FlipSprite();
			direction = 1;
		}

		//Get the Y value;
		yValue = Input.GetAxis ("Vertical");

		if (xValue == 0) {
			speed = 0;
			transform.GetChild(3).GetComponent<Animator>().enabled = false;
			transform.GetChild(3).GetComponent<SpriteRenderer> ().sprite = idle;
		}
//		else if (Input.GetKey(KeyCode.JoystickButton1))
//				speed = runSpeed;
		else {
			speed = walkSpeed;
			transform.GetChild(3).GetComponent<Animator>().enabled = true;

		}



		if (!Input.GetKey (KeyCode.JoystickButton4)) {
				if (xValue != 0) {
					transform.Translate (new Vector2 (speed * xValue * Time.deltaTime, 0));
					target.SetActive(false);
				}
		} 
		else {

			Vector3 direction = new Vector3(xValue, yValue);
			target.SetActive(true);
			target.transform.position = ( transform.position + (direction * 2));
			transform.GetChild(3).GetComponent<Animator>().enabled = false;
			transform.GetChild(3).GetComponent<SpriteRenderer> ().sprite = idle;
			audio.Stop();
		}

		if(grounded && Input.GetKeyDown(KeyCode.JoystickButton0))
			this.rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, (float)jumpPower);
		

	}

	void FlipSprite() {
		isFacingRight = !isFacingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}


}
