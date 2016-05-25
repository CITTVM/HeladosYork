using UnityEngine;
using System.Collections;
using System;

public class BossIA : MonoBehaviour
{

    public Rigidbody2D balaPrefab;
    public float attackSpeed = 0.5f;
    public float cooldown;
    public float bulletSpeed = 500;

    public float ypos = 1f;   //usado para lograr que salga del lugar de ignicion
    public float xpos = 0.2f; // ^ 

    private Transform target;

    public ControlPlayer gameManager;


    public float moveSpeed = 5;
    public float jumpSpeed = 200;
    public Rigidbody2D rb;

    //establezco el daño que recibira
    int damageValue = 1;
    protected double distanciaMaxima = 0;
    protected double distanciaMinima = 0;
    bool DistanciaAgarrada = false;

    // MOVIMIENTO DERECHA A IZQUIERDA DEL ENEMIGO
    bool moveRight = true;

    void Awake()
    {
        gameManager = GameObject.Find("Player").GetComponent<ControlPlayer>();
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Player").GetComponent<ControlPlayer>();
        GameObject tmp = GameObject.FindGameObjectWithTag("Player");
        if (tmp != null)
        {
            this.target = tmp.transform;
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {

        //Asigno a DistanciaMaxima el punto más largo de la plataforma y 
        //a DistanciaMinima el principio de la plataforma
        if (col.gameObject.tag == "Soil")
        {
            ExtraerDistanciaPlataforma(col);
        }


    }

    // Update is called once per frame
    void Update()
    {

        Patrulleo();

        if (Time.time >= cooldown)
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
        }

    }
    public void ExtraerDistanciaPlataforma(Collider2D col)
    {
        if (!DistanciaAgarrada)
        {
            var size = col.GetComponent<Collider2D>();
            distanciaMaxima = col.gameObject.transform.position.x + (size.bounds.size.x / 2);
            distanciaMinima = col.gameObject.transform.position.x - (size.bounds.size.x / 2);
            DistanciaAgarrada = true;
        }
    }

    public void Patrulleo()
    {

        if (moveRight)
        {
            //Movimiento hacia la izquierda siempre y cuando esté en el rango
            if (this.transform.position.x > this.distanciaMinima)
            {
                this.GetComponent<Rigidbody2D>().position -= Vector2.right * moveSpeed * Time.deltaTime;
                this.transform.eulerAngles = new Vector2(0, 180);
            }
            else
            {
                moveRight = false;
            }
        }
        else
        {
            //Movimiento hacia la derecha siempre y cuando esté en el rango
            if (this.transform.position.x < this.distanciaMaxima - 1)
            {
                this.GetComponent<Rigidbody2D>().position += Vector2.right * moveSpeed * Time.deltaTime;
                this.transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                moveRight = true;
            }
        }
    }

    private void Fire()
    {
        Vector2 dir;
        dir = target.transform.position - transform.position;
        dir = dir.normalized;

        Rigidbody2D bPrefab = Instantiate(balaPrefab,
        new Vector3(transform.position.x + xpos,
                    transform.position.y + ypos,
                    transform.position.z),
                    Quaternion.identity) as Rigidbody2D;

        bPrefab.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed);
        cooldown = Time.time + attackSpeed;
    }



    void FixedUpdate()
    {/*
        float horizontal = Input.GetAxis("Horizontal");
        ManejarMovimiento(horizontal);

        //float inputY = Input.GetAxis("Vertical");
  
        
        if (Input.GetKeyDown("space"))
        {
            //rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            //rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            rb.velocity += jumpSpeed * Vector2.up;
        }
        */


    }
    /*private void ManejarMovimiento(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }*/
}
