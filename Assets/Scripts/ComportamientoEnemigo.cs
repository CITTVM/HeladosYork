using UnityEngine;
using System.Collections;

public class ComportamientoEnemigo : MonoBehaviour {
	public float velocidad;
	public GameObject enemigo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3 (velocidad, 0f,0f) * Time.deltaTime;
	}
}
