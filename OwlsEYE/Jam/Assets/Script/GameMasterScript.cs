using UnityEngine;
using System.Collections;

public class GameMasterScript : MonoBehaviour {

	public GameObject[] objects;
	private GameObject mainCamera;


	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		mainCamera.SetActive (false);
		mainCamera.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
