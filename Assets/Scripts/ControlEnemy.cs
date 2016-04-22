using UnityEngine;
using System.Collections;

public class ControlEnemy : MonoBehaviour
{

    //referencia a GameManager
    public ControlPlayer gameManager;


    //establezco el daño que recibira
    int damageValue = 1;
    double distanciaMaxima = 0;
    double distanciaMinima = 0;

    void Awake()
    {
        gameManager = GameObject.Find("Player").GetComponent <ControlPlayer>() ;
    }
    // GENERAR COLISION
    // Si colisiona el enemigo (ontrigger porque el enemigo tiene un boxcollider2d con ontrigger activado)
    // se produce el metodo de que toma daño y el metodo que quita vida


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            gameManager.SendMessage("PlayerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
            //gameManager.controlPlayer.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);
            gameManager.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);

        }else
        {
            //Asigno a DistanciaMaxima el punto más largo de la plataforma y 
            //a DistanciaMinima el principio de la plataforma
            if (col.gameObject.tag == "Soil")
            {
                var size = col.GetComponent<Collider2D>();
             
                distanciaMaxima = col.gameObject.transform.position.x + (size.bounds.size.x / 2);
                distanciaMinima = col.gameObject.transform.position.x - (size.bounds.size.x / 2);
            }


        }


    }



    // MOVIMIENTO DERECHA A IZQUIERDA DEL ENEMIGO
 /*  float inicioPos;
    float finPos;*/

  //  public int unitsToMove = 5;
    public int moveSpeed = 10;
    bool moveRight = true;

    void Update()
    {
        
        if(moveRight)
        {
            //Movimiento hacia la izquierda siempre y cuando esté en el rango
            if (this.transform.position.x > this.distanciaMinima)
            {
                GetComponent<Rigidbody2D>().position -= Vector2.right * moveSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector2(0, 180);
            }else
            {
                moveRight = false;
            }
        }else
        {
            //Movimiento hacia la derecha siempre y cuando esté en el rango
            if (this.transform.position.x < this.distanciaMaxima-1)
            {
                GetComponent<Rigidbody2D>().position += Vector2.right * moveSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                moveRight = true;
            }
}

        

    }
           
}

