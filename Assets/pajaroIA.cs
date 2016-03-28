using UnityEngine;
using System.Collections;

public class pajaroIA : MonoBehaviour
{

    // Use this for initialization


    public int a;
    public int b;
    public float centroX;
    public float centroY;
    public int alpha;
    public float coordenadaX;
    public float coordenadaY;
    public bool ataque = false;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {

            ataque = true;
        }
    }

        void Start()
    {
        ataque = true;
    }

    void Awake()
    {
        centroX = this.transform.position.x;
        centroY = this.transform.position.y;
        
    }
    void Update()
    {

        if (ataque)
        {
           

                alpha += 10;
                coordenadaX = centroX + (a * Mathf.Sin(alpha * .005f));
                coordenadaY = centroY + (b * Mathf.Cos(alpha * .005f));
                this.gameObject.transform.position = new Vector2(coordenadaX, coordenadaY);

            if (alpha > 1220)
            {
                ataque = false;
                alpha = 0;
            }

        }

     }
       
 }



