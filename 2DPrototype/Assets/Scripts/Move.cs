using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public int walkSpeed = 10;
	public int runSpeed = 20;
	public int speed = 0;
	public int jumpPower = 50;
	public bool isFacingRight = true;
	public bool grounded;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float value = Input.GetAxis ("Horizontal");

		if (value < 0 && isFacingRight) {
			FlipSprite();
		}
		if (value > 0 && !isFacingRight) {
			FlipSprite();
		}

		if (value == 0)
				speed = 0;
		else if (Input.GetAxis ("Fire2") > 0) 
				speed = runSpeed;
		else
				speed = walkSpeed;

		if(value != 0)	{
			this.rigidbody2D.velocity = new Vector2(speed * value ,rigidbody2D.velocity.y);
			//rigidbody2D.AddForce (Vector2.right * value * speed);
		}

		//RaycastHit2D rayGrounded = Physics2D.Linecast ((Vector2) transform.position, (Vector2)transform.position - Vector2.up);

		if(grounded && Input.GetAxis("Jump") == 1)
			this.rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, (float)jumpPower);
		

	}

	void FlipSprite() {
		isFacingRight = !isFacingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void OnTriggerEnter2D() {
		grounded = true;
	}
	void OnTriggerStay2D() {
		grounded = true;
	}
	void OnTriggerExit2D() {
		grounded = false;
	}
}
