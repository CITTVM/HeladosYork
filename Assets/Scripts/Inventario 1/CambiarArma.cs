using UnityEngine;
using System.Collections;

public class CambiarArma: MonoBehaviour {

	public GameObject weapon01;
	public GameObject weapon02;
	public Rigidbody2D bullet1;
	public Rigidbody2D bullet2;


	void Start(){
		
		//weapon03.SetActive(false);
		weapon02.SetActive(true);
		weapon01.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Q)) {

			switchWeaponsPlease ();
		}


	if (Input.GetKeyDown (KeyCode.F))
				BulletAttack ();

		


	}


	public void BulletAttack(){

		if (weapon01.activeSelf) {
			
			Rigidbody2D bPrefab = Instantiate (bullet1, transform.position, Quaternion.identity) as Rigidbody2D;
			bPrefab.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 500);





			//weapon03.SetActive(true);
		} else {
			
			Rigidbody2D bPrefab = Instantiate (bullet2, transform.position, Quaternion.identity) as Rigidbody2D;
			bPrefab.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 500);




		
		}
	}

		void switchWeaponsPlease(){

			if (weapon01.activeSelf){
				weapon01.SetActive(false);
				weapon02.SetActive(true);





			    //weapon03.SetActive(true);
			}
			else{
				weapon01.SetActive(true);
			weapon02.SetActive(false);
			//weapon02.SetActive(true);

		}











	
	}
}
