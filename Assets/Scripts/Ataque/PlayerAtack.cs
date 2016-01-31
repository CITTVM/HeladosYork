using UnityEngine;
using System.Collections;

public class PlayerAtack : MonoBehaviour {

	// Use this for initialization
	public Rigidbody2D bulletPrefab;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F))
			BulletAttack ();
	
	}

	public void BulletAttack(){

		Rigidbody2D bPrefab = Instantiate(bulletPrefab,transform.position,Quaternion.identity) as Rigidbody2D;
		bPrefab.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500);
	}


}
