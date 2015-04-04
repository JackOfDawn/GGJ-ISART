using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoutonScript : MonoBehaviour {

	public bool enable = false;

	void Start () {
		enable = transform.parent.transform.parent.transform.parent.GetComponent<ObjetScript> ().combineEnable;
		
		if (enable == false) {
			gameObject.GetComponent<Image> ().color = new Color (0.3f, 0.3f, 0.3f, 1);
		} else {
			gameObject.GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
	}
	
	// Update is called once per frame
	void Update () {

		enable = transform.parent.transform.parent.transform.parent.GetComponent<ObjetScript> ().combineEnable;

		if (enable == false) {
			gameObject.GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
		} else {
			gameObject.GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
	}
}
