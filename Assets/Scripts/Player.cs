using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Salto de Player
		if (Input.GetKeyUp("space")) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(0,300));
		}
		//Avance a la derecha.
		if (Input.GetKey("right")) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(50,0));
		}
		//Avance izquierda
		if (Input.GetKey("left")) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(-50,0));
		}

		//posible poder
		/*if (Input.GetKeyUp("alt")) {
			
		}*/
	}
}
