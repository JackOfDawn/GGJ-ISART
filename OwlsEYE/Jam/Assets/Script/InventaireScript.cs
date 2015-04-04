using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventaireScript : MonoBehaviour {

	public GameObject[] sprite;
	private int ID;

	void Update () {
		ID = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID;

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().objectID == 0) {
			foreach (Transform Inventaire in transform){
				Inventaire.GetComponent<Image>().enabled = false;
			}
		} 
		else {
			foreach (Transform Inventaire in transform){
				Inventaire.GetComponent<Image>().enabled = false;
			}
			sprite[ID].SetActive (true);
			sprite[ID].GetComponent<Image>().enabled = true;
		}
	}
}
