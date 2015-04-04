using UnityEngine;
using System.Collections;

public class Move2 : MonoBehaviour {

	public int walkSpeed = 10;
	public int runSpeed = 20;
	public int speed = 0;
	public int jumpPower = 5;
	public bool isFacingRight = true;
	public bool grounded;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		grounded = transform.GetChild (2).GetComponent<GroundDetectionScript> ().grounded;

		float value = Input.GetAxis ("Horizontal");

		if (value < 0 && isFacingRight) {
			FlipSprite();
		}
		if (value > 0 && !isFacingRight) {
			FlipSprite();
		}

		if (value == 0)
				speed = 0;
		else
				speed = walkSpeed;

		if(value != 0)	{
			transform.Translate ( new Vector2(speed * value * Time.deltaTime, 0));
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
