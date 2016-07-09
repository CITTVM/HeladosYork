using UnityEngine;
using System.Collections;

public class EnemyVista : MonoBehaviour {
    [SerializeField]
    private Enemy enemy;

void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.Target = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.Target = null;
        }
    }
}
