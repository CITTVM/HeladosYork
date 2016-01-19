using UnityEngine;
using System.Collections;

public class ControlEnemy : MonoBehaviour {
	
	//referencia a GameManager
	public GameManager gameManager;




	//establezco el daño que recibira
	int damageValue = 1;


	// GENERAR COLISION
	// Si colisiona el enemigo (ontrigger porque el enemigo tiene un boxcollider2d con ontrigger activado)
	// se produce el metodo de que toma daño y el metodo que quita vida


	void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag == "Player"){
			gameManager.SendMessage("PlayerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
			gameManager.controlPlayer.SendMessage ("TakenDamage", SendMessageOptions.DontRequireReceiver);

		}
	}



	// MOVIMIENTO DERECHA A IZQUIERDA DEL ENEMIGO
	float inicioPos;
	float finPos;

	public int unitsToMove = 5;
	public int moveSpeed = 2;
	bool moveRight =true;

	void Awake(){

		inicioPos = transform.position.x;
		finPos = inicioPos + unitsToMove;
	}

	void Update () {

		if (moveRight){

			GetComponent<Rigidbody2D>().position += Vector2.right * moveSpeed * Time.deltaTime;
		}

		if(GetComponent<Rigidbody2D>().position.x >= finPos){
			moveRight = false;

		}

		if (!moveRight) {
			

			GetComponent<Rigidbody2D>().position -= Vector2.right * moveSpeed * Time.deltaTime;
		}


		if(GetComponent<Rigidbody2D>().position.x <= inicioPos){

			moveRight = true;
		}




	}
}
