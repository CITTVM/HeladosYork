using UnityEngine;
using System.Collections;

public class FollowEnemy : MonoBehaviour {
	public float walkSpeed;
	public float maxFallSpeed;
	public float jumpImpulse;


	//referencia a GameManager
	public GameManager gameManager;

     //establezco el daño que recibira
	int damageValue = 1;



	private Transform target;
	private Rigidbody2D body;
	private Vector2 movement;

	private float horInput;



	public bool isGrounded = false;
	public Transform compSuelo;
	float comprobadorRadio =0.03f;
	public LayerMask mascaraSuelo;




	private float time;


	// =============================
	void Start () {

		this.body = this.GetComponent<Rigidbody2D>();
		this.movement = new Vector2();
		 

		this.time = 0;


		GameObject tmp = GameObject.FindGameObjectWithTag("Player");
		if(tmp != null){
			this.target = tmp.transform;
		}
	}
	// =============================
	void Update () {
		this.time += Time.deltaTime;

		// search for the player
		if (this.target) {
			if (this.transform.position.x < this.target.position.x) {
				this.horInput = 1;
			} else if (this.transform.position.x > this.target.position.x) {
				this.horInput = -1;
			}
		} else {
			this.horInput = 0;
		}
	}

	// =============================
	void FixedUpdate(){
		isGrounded = Physics2D.OverlapCircle (compSuelo.position, comprobadorRadio, mascaraSuelo);
		this.movement = this.body.velocity;

		// Movimiento horizontal
		this.movement.x = horInput * walkSpeed;

		// Limitacion de la velocidad de caida
		if( !this.isGrounded ){
			if(this.movement.y < this.maxFallSpeed){
				this.movement.y = this.maxFallSpeed;
			}
		}

		this.body.velocity = this.movement;
	}
	// =============================
	// =============================
	void Detect(){
		//Collider2D tmp = Physics2D.OverlapCircle(compSuelo.position, comprobadorRadio, mascaraSuelo);
		//if(tmp){
			//if(tmp.gameObject.CompareTag("Player")){
				
			//}else{
				if(this.isGrounded){
					this.movement.y = jumpImpulse;
				//}
			//}
		}
	}

	void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag == "Player"){
			gameManager.SendMessage("PlayerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
			gameManager.controlPlayer.SendMessage ("TakenDamage", SendMessageOptions.DontRequireReceiver);

		}
	}
	// =============================

}
