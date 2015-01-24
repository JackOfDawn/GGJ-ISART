using UnityEngine;
using System.Collections;

public class ThrowableScript : MonoBehaviour {

	// Use this for initialization
	public GameObject playerRef;
	public int speed = 5;
	public float activeSeconds = 3;
	private int direction = 1; // 1 = right, -1 = left
	public int playerSpeed = 0;
	private float remainingSeconds;


	void Start () {
		remainingSeconds = activeSeconds;
		playerRef = GameObject.FindGameObjectWithTag ("Player");
		if (playerRef) {
			Move playerMove = playerRef.GetComponent<Move> ();
			if(playerMove)
			{
				if (playerMove.isFacingRight)
					direction = 1;
				else
					direction = -1;
				playerSpeed = playerMove.speed;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 velocity = rigidbody2D.velocity;
		velocity.x = (playerSpeed + speed) * direction;// * Time.deltaTime;
		rigidbody2D.velocity = velocity;

		remainingSeconds -= Time.deltaTime;
		if (remainingSeconds <= 0) {
			Destroy(this.gameObject);
		}
	}

}
