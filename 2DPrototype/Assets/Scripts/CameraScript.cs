using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject playerCharacter;
	public float zOffset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (playerCharacter.transform.position.x, playerCharacter.transform.position.y, zOffset);
	}
}
