using UnityEngine;
using System.Collections;

public class ThrowableScript : MonoBehaviour {

	// Use this for initialization
	public GameObject playerRef;
	public int speed = 5;
	public float activeSeconds = 3;
	private Vector2 direction; // 1 = right, -1 = left
	public int playerSpeed = 0;
	private float remainingSeconds;


	void Start () {
		remainingSeconds = activeSeconds;
		playerRef = GameObject.FindGameObjectWithTag ("Player");
		if (playerRef) {
			Move playerMove = playerRef.GetComponent<Move> ();
			if(playerMove)
			{
				playerSpeed = playerMove.speed;
				direction.y = playerMove.yValue;
				direction.x = playerMove.xValue;
				if(direction == Vector2.zero)
				{
					direction.x = playerMove.direction;
				}
			}
		}

	}


	// Update is called once per frame
	void Update () {
		Vector2 velocity = rigidbody2D.velocity;
		velocity = (playerSpeed + speed) * direction;// * Time.deltaTime;
		rigidbody2D.velocity = velocity;

		remainingSeconds -= Time.deltaTime;
		if (remainingSeconds <= 0) {
			Destroy(this.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D laCollision)
	{
		if (laCollision.collider.tag != "Player")
			remainingSeconds = 0;
	}
}
