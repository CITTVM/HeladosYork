using UnityEngine;
using System.Collections;

public class switchWeapons : MonoBehaviour {

	public GameObject weapon01;
	public GameObject weapon02;

	void Start(){

		weapon02.SetActive(false);
		weapon01.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Q)) {

			switchWeaponsPlease ();
		}
	}

		void switchWeaponsPlease(){

			if (weapon01.activeSelf){
				weapon01.SetActive(false);
				weapon02.SetActive(true);
			}
			else{
				weapon01.SetActive(true);
			weapon02.SetActive(false);

		}











	
	}
}
