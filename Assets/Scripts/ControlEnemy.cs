using UnityEngine;
using System.Collections;

public class ControlEnemy : MonoBehaviour {
	// PARA LA COLICION

	public GameManager gameManager;


	int damageValue = 1;
	// GENERAR COLISION
	void OnTriggerEnter(Collider col){

		if(col.gameObject.tag == "player_fly_f01"){
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
