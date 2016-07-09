using UnityEngine;
using System.Collections;

public class Enemy : Character
{

    private IEnemyState currentState;

    public GameObject Target { get; set; }

    // Use this for initialization
    public int a;
    public int b;
    private int alpha; //
    private float centroX;
    private float centroY;

    public override void Start()
    {
        base.Start();
        ChangeState(new IdleState());
    }

    void Update()
    {
        currentState.Execute();
    }

    public void ChangeState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter(this);

    }

    public void Awake()
    {
        centroX = this.transform.position.x; //CentroX es la posición actual del ovni-pajaro en el EJE X
        centroY = this.transform.position.y; //CentroY es la posición actual del ovni-pajaro en el EJE Y

    }

    public void Ataque()
    {

        alpha += 10;

        float coordenadaX = centroX + (a * Mathf.Sin(alpha * .005f)); //Ecuación mat movimiento circular y ovalado en el eje X
        float coordenadaY = centroY + (b * Mathf.Cos(alpha * .005f)); //Ecuación mat movimiento circular y ovalado en el eje Y

        this.gameObject.transform.position = new Vector2(coordenadaX, coordenadaY); //MOVIMIENTO CIRCUlAR A TRAVES DE LOS EJES X e Y

        if (alpha > 1220) //una vuelta completa hasta el inicio de la prox vuelta.
        {

            alpha = 0;
        }


    }


}
