using UnityEngine;
using System.Collections;

public class ControlPlayer : MonoBehaviour
{

	//Variables Movimiento

  	public float Velocidad=15;
	public float Salto=25;
	float moveVelocity;



	//takendamage
	float takenDamage = 0.2f;





	//Variables enSuelo

	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	float comprobadorRadio = 1.5f;
	public LayerMask mascaraSuelo;

	void FixedUpdate(){
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
	}

	void Update ()
	{
		//Salto
		if (enSuelo && Input.GetKeyDown (KeyCode.Space))
		{


				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, Salto);

		}

		moveVelocity = 0;

		//Movimiento derecha izquierda
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			moveVelocity = -Velocidad;
		}
		if (Input.GetKey (KeyCode.RightArrow))
		{
			moveVelocity = Velocidad;
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

	}
	//Chequear ensuelo
	void OnTriggerEnter2D()
	{
		enSuelo = true;
	}
	void OnTriggerExit2D()
	{
		enSuelo = false;
	}


	public IEnumerator TakenDamage(){
		GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(takenDamage);
		GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds(takenDamage);
		GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(takenDamage);
		GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds(takenDamage);
		GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(takenDamage);
		GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds(takenDamage);
	}
}