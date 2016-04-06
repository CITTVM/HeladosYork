using UnityEngine;
using System.Collections;

public class attack_ovni : MonoBehaviour {

      //referencia a ControlPlayer
    public ControlPlayer gameManager;


    //establezco el daño que recibira
    int damageValue = 1;

    

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("Player").GetComponent<ControlPlayer>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            gameManager.SendMessage("PlayerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
            gameManager.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);
        }
    }
}
