using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject playerCharacter;

	public float speedAdjustment = 5.0f;

	public float zOffset;
	public float xScale = 9;
	public float yScale = 5;

	public Vector3 direction;
	public float scale = 2.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

		direction.x = Input.GetAxis ("RightH");
		direction.y = -Input.GetAxis ("RightV");



		Vector3 position = playerCharacter.transform.position;
		position.z = zOffset;

		direction.x *= xScale;
		direction.y *= yScale;
		position += (direction);

		//transform.position.y = position.y;
		position.x = Mathf.Lerp(transform.position.x, position.x, speedAdjustment * Time.deltaTime);
		position.y = Mathf.Lerp(transform.position.y, position.y, speedAdjustment * Time.deltaTime);
		transform.position = position;//new Vector3 (playerCharacter.transform.position.x + xOffset, playerCharacter.transform.position.y = yOffset, zOffset);
	}
}
