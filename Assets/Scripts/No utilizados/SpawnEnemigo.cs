using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemigo : MonoBehaviour {

	public float alturaMaxima;
	public float alturaMinima;		 
	public float rateSpawn; 

	public GameObject prefabricado;
	public List<GameObject> Enemigos;
	public int maximoEnemigos;
	private float posicionAzar;
	private float currentRateSpawn;

	// Use this for initialization
	void Start () {

		for(int i=0;i<maximoEnemigos;i++){
			GameObject enemigoTMP = Instantiate (prefabricado) as GameObject;
			Enemigos.Add (enemigoTMP);
			enemigoTMP.SetActive (false);


		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
		currentRateSpawn = currentRateSpawn + Time.deltaTime;
		if (currentRateSpawn > rateSpawn) {
		
			currentRateSpawn = 0;
			Spawn ();
		
		}
	}

		//metodo spawn
		void Spawn(){
			int azarPos = Random.Range(0,9);
			if (azarPos<5){
				posicionAzar=alturaMaxima;
			}

			else{
				posicionAzar=alturaMinima;
			    }
			GameObject enemigoTMP=null;
			for (int i=0;i<maximoEnemigos;i++){

				if(Enemigos [i].activeSelf==false){
					enemigoTMP=Enemigos [i];
					break;
			}

		}

			if (enemigoTMP!=null){

				enemigoTMP.transform.position= new Vector2(transform.position.x,posicionAzar);
				enemigoTMP.SetActive(true);
			}




	}
}
