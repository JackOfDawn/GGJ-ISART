using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public int speed = 10;
	public int jumpPower = 50;
	public bool isFacingRight = true;
	public bool grounded;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float value = Input.GetAxis ("Horizontal");

		if(value != 0)	{
			rigidbody2D.AddForce (Vector2.right * value * speed);
		}

		RaycastHit2D rayGrounded = Physics2D.Linecast ((Vector2) transform.position, (Vector2)transform.position - Vector2.up);

		if(grounded && Input.GetAxis("Jump") == 1)
			this.rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, (float)jumpPower);
		

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
