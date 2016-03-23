using UnityEngine;
using System.Collections;

public class Rotacion : MonoBehaviour {
    //referencia a GameManager
    public GameManager gameManager;




    //establezco el daño que recibira
    int damageValue = 1;



    // GENERAR COLISION
    // Si colisiona el enemigo (ontrigger porque el enemigo tiene un boxcollider2d con ontrigger activado)
    // se produce el metodo de que toma daño y el metodo que quita vida
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            gameManager.SendMessage("PlayerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
            gameManager.controlPlayer.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);

        }

    }
     void Update () 
    {
        RotacionObstaculo();
	}



     void RotacionObstaculo()
    {
        transform.Rotate(Vector3.forward * -10);
    }
}
