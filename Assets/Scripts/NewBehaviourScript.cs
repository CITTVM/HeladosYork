using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	// PARA LA COLICION
	//referencia al script controlplayer
	public Manejo manejo;

	int damageValue = 1;

	void OnTriggerEnter(Collider col){

	if(col.gameObject.tag == "player_fly_f01"){
			manejo.SendMessage("PlayerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
			manejo.manejo.SendMessage("TakenDamage",SendMessageOptions.DontRequireReceiver);

		}
	}











	// MOVIMIENTO DERECHA A IZQUIERDA
	float inicioPos;
	float finPos;

	public int unitsToMove = 5;
	public int moveSpeed = 2;
	bool moveRight =true;

	void Awake(){
		
		inicioPos = transform.position.x;
		finPos = inicioPos + unitsToMove;
}


	
	// Update is called once per frame
	void Update () {
	
		if (moveRight){
		
			GetComponent<Rigidbody>().position += Vector3.right * moveSpeed * Time.deltaTime;
		}

		if(GetComponent<Rigidbody>().position.x >= finPos){
			moveRight = false;

		}

		if (!moveRight) {
		
			GetComponent<Rigidbody>().position -= Vector3.right * moveSpeed * Time.deltaTime;
		}


		if(GetComponent<Rigidbody>().position.x <= inicioPos){

			moveRight = true;
		}




	}
}
