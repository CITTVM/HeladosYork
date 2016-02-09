using UnityEngine;
using System.Collections;

public class AñadirObjetoporColision : MonoBehaviour {


	//referencia al script jugadorinventario
	public JugadorInventario jugadorInventario;


	public GameObject bullet1;
	public GameObject bullet2;
	//id de los helados en la bd
	public int ID;


	void Start(){

		//weapon03.SetActive(false);
		//bullet1.SetActive(false);
		//bullet2.SetActive(false);
	}


	// cuando colisione el personaje con 1 helado este se agrega al inventario y se activa el arma

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			jugadorInventario.AgregarObjeto (ID);
			Destroy (gameObject);
			bullet2.SetActive (true);



			}



		}


	void Ontr (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			jugadorInventario.AgregarObjeto (ID);
			Destroy (gameObject);
			bullet2.SetActive (true);



		}



	}


	}







	

	



	
