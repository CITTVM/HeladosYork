using UnityEngine;
using System.Collections;

public class AtaqueConHelados : MonoBehaviour {


	public GameObject bullet1;
	public GameObject bullet2;



	void Start(){



	}

	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.F))
			BulletAttack();

	}


	public void BulletAttack(){

		if (bullet1.activeSelf) {

			GameObject bPrefab = Instantiate (bullet1, transform.position, Quaternion.identity) as GameObject;
			bPrefab.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 900);


		
		} else {

			GameObject bPrefab = Instantiate (bullet2, transform.position, Quaternion.identity) as GameObject;
			bPrefab.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 900);





		}
	}














	}



