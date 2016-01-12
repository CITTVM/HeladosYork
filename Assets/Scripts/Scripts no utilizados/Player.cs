using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	float comprobadorRadio = 0.04f;
	public LayerMask mascaraSuelo;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate(){
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
	}
	
	// Update is called once per frame
	void Update () {
		//Salto de Player
		if (enSuelo && Input.GetKeyUp("space")) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(0,300));
		}
		//Avance a la derecha.
		if (Input.GetKey("right")) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(30,0));
		}
		//Avance izquierda
		if (Input.GetKey("left")) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(-30,0));
		}

		//posible poder
		/*if (Input.GetKeyUp("alt")) {
			
		}*/
	}
}
