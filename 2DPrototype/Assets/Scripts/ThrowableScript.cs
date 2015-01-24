using UnityEngine;
using System.Collections;

public class ThrowableScript : MonoBehaviour {

	// Use this for initialization
	public int speed = 5;
	public float activeSeconds = 3;
	public int direction = 1; // 1 = right, -1 = left
	private float remainingSeconds;
	void Start () {
		remainingSeconds = activeSeconds;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 velocity = rigidbody2D.velocity;
		velocity.x = speed * direction;// * Time.deltaTime;
		rigidbody2D.velocity = velocity;

		remainingSeconds -= Time.deltaTime;
		if (remainingSeconds <= 0) {
			Destroy(this.gameObject);
		}
	}

	public void setDirection()
	{

	}
}
