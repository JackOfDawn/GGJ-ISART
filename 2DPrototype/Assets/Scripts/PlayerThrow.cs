using UnityEngine;
using System.Collections;

public class PlayerThrow : MonoBehaviour {

	// Use this for initialization
	public GameObject playerRef;
	public GameObject throwable;
	public float MAX_COOLDOWN = 1;
	private float cooldown;

	void Start () {
	
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
		Instantiate (throwable, transform.position, Quaternion.identity);
		ThrowableScript shot = throwable.GetComponent<ThrowableScript>();
		if (shot) {
			Move playerMove = playerRef.GetComponent<Move>();
			if(playerMove)	{
				if(playerMove.isFacingRight)
					shot.direction = 1;
				else
					shot.direction = -1;
			}
		}
	}
}
