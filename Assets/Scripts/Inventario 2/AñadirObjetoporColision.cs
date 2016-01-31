using UnityEngine;
using System.Collections;

public class AñadirObjetoporColision : MonoBehaviour {

	public JugadorInventario jugadorInventario;
	public int ID;






	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			jugadorInventario.AgregarObjeto(ID);
			Destroy (gameObject);
		}
	}

}
