using UnityEngine;
using System.Collections;

public class ThrowableScript : MonoBehaviour {

	// Use this for initialization
	public int speed = 5;
	public float activeSeconds = 3;
	public int direction; // 1 = right, -1 = left
	public int playerSpeed;
	private float remainingSeconds;
	void Start () {
		remainingSeconds = activeSeconds;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 velocity = rigidbody2D.velocity;
		velocity.x = (playerSpeed + speed) * direction;// * Time.deltaTime;
		print (direction);
		rigidbody2D.velocity = velocity;

		remainingSeconds -= Time.deltaTime;
		if (remainingSeconds <= 0) {
			Destroy(this.gameObject);
		}
	}

}
