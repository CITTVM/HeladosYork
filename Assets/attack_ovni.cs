using UnityEngine;
using System.Collections;

public class attack_ovni : MonoBehaviour {

    //referencia a GameManager
    public GameManager gameManager;

    //establezco el daño que recibira
    int damageValue = 1;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            gameManager.SendMessage("PlayerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
            gameManager.controlPlayer.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);

        }
    }

        // Use this for initialization
        void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
