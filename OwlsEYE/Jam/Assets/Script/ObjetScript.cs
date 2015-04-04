using UnityEngine;
using System.Collections;

public class ObjetScript : MonoBehaviour {

	public Sprite normal;
	public Sprite glow;

	private bool detected = false;
	public int ID;
	public int actualPlayerID;
	private GameObject textBox;
	public bool combineEnable;
	private bool actionable;
	public bool leverActivated;
	public GameObject brokenBridge;
	public Sprite leverRight;
	public Sprite leverLeft;
	public Sprite glowLeverRight;
	
	void Start(){
		textBox = transform.GetChild (0).gameObject;
		textBox.SetActive (false);
		actionable = false;
		leverActivated = false;
	}

	void Update () {

		actualPlayerID = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID;

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 1 && ID == 2 || 
		    GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 2 && ID == 1 ||
		    GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 1 && ID == 4 ||
		    GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 5 && ID == 3 ||
		    GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 5 && ID == 6 ||
		    GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 5 && ID == 7 ||
		    GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 7 && ID == 4 ||
		    GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 7 && ID == 5 ||
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 8 && ID == 9 ||
		    GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 1 && ID == 10 ||
		    GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 10 && ID == 1 ||
		    GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 1 && ID == 12 ||
		    GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 11 && ID == 4){

			combineEnable = true;
		} else {
			combineEnable = false;
		}

		if (actionable == true) {
			if (Input.GetKeyDown (KeyCode.JoystickButton2) && gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).name == "ButtonPickUp"){
				PickUp();
			}
			if (Input.GetKeyDown (KeyCode.JoystickButton3)){
				Use();
				Combine();
			}
		}

		if (detected == true) {
			if (ID == 13){
				if (leverActivated == false){
					gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = glow; 
				}
				else {
					gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = glowLeverRight; 
				}
			}
			else {
				gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = glow; 
			}
			if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
				textBox.SetActive(true);
				actionable = true;
			}
		} else {
			if(ID == 13){
				if (leverActivated == false){
					gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = leverLeft; 
				}
				else {
					gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = leverRight; 
				}
			}
			else {
				gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = normal; 
				actionable = false;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D Detection){
		if (Detection.gameObject.tag == "PlayerDetection"){
			detected = true;
		}
	}

	void OnTriggerStay2D (Collider2D Detection){
		if (Detection.gameObject.tag == "PlayerDetection"){
			detected = true;
		}
	}

	void OnTriggerExit2D (Collider2D Detection){
		if (Detection.gameObject.tag == "PlayerDetection"){
			detected = false;
			textBox.SetActive(false);
		}
	}

	public void PickUp(){
		AudioSource.PlayClipAtPoint(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundManagerScript>().PickUp, transform.position);

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID != 0) {
			Instantiate (GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameMasterScript> ().objects[actualPlayerID], new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), transform.rotation);
		} 
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID = ID;
		Destroy (gameObject);
	}

	public void Combine(){
		AudioSource.PlayClipAtPoint(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundManagerScript>().Combine, transform.position);

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 1 && ID == 10 || GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 10 && ID == 1) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().objectID = 11;
			Destroy(gameObject);
		}
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 1 && ID == 12) {
			Instantiate (GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameMasterScript> ().objects[13], new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), transform.rotation);
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().objectID = 0;
			Destroy(gameObject);
		}
		textBox.SetActive(false);
		actionable = false;
	}

	public void Use(){
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 1 && ID == 4) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().objectID = 5;
		}

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 5 && ID == 3) {
			Instantiate (GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameMasterScript> ().objects[4], new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), transform.rotation);
			Destroy(gameObject);
		}

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 5 && ID == 6) {
			gameObject.transform.GetChild(1).gameObject.SetActive(false);
			brokenBridge.SetActive(true);
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			ID = 99;
		}

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 5 && ID == 7) {
			Instantiate (GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameMasterScript> ().objects[8], new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), transform.rotation);
			GameObject.FindGameObjectWithTag ("GameController").transform.GetChild (0).transform.GetChild (0).GetComponent<DynamiteScript> ().dynamite = true;
			Destroy(gameObject);
		}

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 7 && ID == 4) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().objectID = 8;
			GameObject.FindGameObjectWithTag ("GameController").transform.GetChild (0).transform.GetChild (0).GetComponent<DynamiteScript> ().dynamite = true;
		} 

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 7 && ID == 5) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().objectID = 8;
			GameObject.FindGameObjectWithTag ("GameController").transform.GetChild (0).transform.GetChild (0).GetComponent<DynamiteScript> ().dynamite = true;
		} 

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 8 && ID == 9) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().objectID = 0;
			GameObject.FindGameObjectWithTag ("GameController").transform.GetChild (0).transform.GetChild (0).GetComponent<DynamiteScript> ().dynamite = false;
			Destroy(gameObject);
		}

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 11 && ID == 4) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().objectID = 14;
		}

		if (ID == 13) {
			if (leverActivated == false){
				leverActivated = true;
				GameObject.FindGameObjectWithTag("GameController").GetComponent<TutoScript>().leverActivated = true;
			}
			else{
				leverActivated = false;
				GameObject.FindGameObjectWithTag("GameController").GetComponent<TutoScript>().leverActivated = false;
			}
		}
		textBox.SetActive(false);
		actionable = false;
	}
}
