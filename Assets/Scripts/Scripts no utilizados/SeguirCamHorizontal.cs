using UnityEngine;
using System.Collections;

public class SeguirCam : MonoBehaviour {

	public Transform Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3 (Player.position.x, transform.position.y, transform.position.z);
	}
}
