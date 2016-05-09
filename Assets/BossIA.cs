using UnityEngine;
using System.Collections;
using System;

public class BossIA : MonoBehaviour {

    public Rigidbody2D balaPrefab;
    public float attackSpeed = 0.5f;
    public float cooldown;
    public float bulletSpeed = 500;

    public float ypos = 1f;   //usado para lograr que salga del lugar de ignicion
    public float xpos = 0.2f; // ^ 

    private Transform target;

    public ControlPlayer gameManager;


    public float moveSpeed = 5;
    public Rigidbody2D rb;


    // Use this for initialization
    void Start () {
        rb= GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Player").GetComponent<ControlPlayer>();
        GameObject tmp = GameObject.FindGameObjectWithTag("Player");
        if (tmp != null)
        {
            this.target = tmp.transform;
        }

    }
	
	// Update is called once per frame
	void Update () {
        

        if (Time.time >= cooldown)
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
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
    {
        float horizontal = Input.GetAxis("Horizontal");
        ManejarMovimiento(horizontal);
        
    }
    private void ManejarMovimiento(float horizontal)
    {
        rb.velocity = new Vector2(horizontal*moveSpeed, rb.velocity.y);
    }
}
