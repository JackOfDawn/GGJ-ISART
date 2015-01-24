using UnityEngine;
using System.Collections;

public class PlayerThrow : MonoBehaviour {

	// Use this for initialization
	public GameObject throwable;
	public int xOffset = 1;
	public float MAX_COOLDOWN = 1;
	private float cooldown;
	private Vector3 offset;
	void Start () {
		offset = new Vector3 (xOffset, 0 , 0);
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		//if throw button is press, create throwable with velocity in player's direction?
		if (Input.GetAxis ("Fire1") == 1  && cooldown < 0) {
			CreateThrowable();
			cooldown = MAX_COOLDOWN;
		}
	}

	void CreateThrowable()	{
		Move playerMove = gameObject.GetComponent<Move>();
		if (playerMove) {
			int direction;
			if (playerMove.isFacingRight)
				direction = 1;
			else
				direction = -1;

			Instantiate (throwable, transform.position + (offset * direction), Quaternion.identity);

			ThrowableScript shot = throwable.GetComponent<ThrowableScript> ();
			if (shot) {
				shot.playerSpeed = playerMove.speed;
				shot.direction = direction;
			}
		}
	}
}
