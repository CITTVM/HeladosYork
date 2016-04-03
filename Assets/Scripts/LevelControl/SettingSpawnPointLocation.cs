using UnityEngine;
using System.Collections;

public class SettingSpawnPointLocation : MonoBehaviour {

    public GameObject[] spawns;
    private Vector3[] vectores;
    private int contador = 0;
    /////Enemigo1 volador/////
    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    private int aire = 0;
    private int[] specialSpawn;
    public int cantidadEnemigos;



	// Use this for initialization
	void Start () {
        spawns = GameObject.FindGameObjectsWithTag("Soil");
        vectores = new Vector3[spawns.Length];
        specialSpawn = new int[spawns.Length];

        foreach (GameObject spawn in spawns)
        {
            if (Random.Range(0f,1f) >= 0.5f)
            {
                vectores[contador] = new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, 0);
                contador++;
            }
            else
            {
                vectores[contador] = new Vector3(spawn.transform.position.x, spawn.transform.position.y + 3, 0);
                specialSpawn[aire] = contador;
                contador++;
                aire++;
            }
        }
	}

    void Awake()
    {
        //enemigo1.gameObject.
    }

    // Update is called once per frame
    void Update () {
        InstanciacionProcedimental();
	}

    //private void InstanciacionProcedimental()
    //{
    //    float indicador = Random.Range(0f, 1f);
    //    int spawnPoint = Random.Range(0, spawns.Length);
    //    int verificador = 0;
    //    if (GameObject.FindGameObjectsWithTag("Enemy").Length < cantidadEnemigos)
    //    {
    //        if (indicador > 0f && indicador < 0.3f)
    //        {
    //            foreach (int spawn in specialSpawn)
    //            {
    //                if (spawnPoint == spawn)
    //                {
    //                    Instantiate(enemigo1, new Vector3(vectores[spawnPoint].x, vectores[spawnPoint].y, vectores[spawnPoint].z), Quaternion.identity);
    //                }
    //                else
    //                {
    //                    verificador++;
    //                }
    //            }
    //            if (verificador == specialSpawn.Length)
    //            {
    //                verificador = 0;
    //                Instantiate(enemigo2, new Vector3(vectores[spawnPoint].x, vectores[spawnPoint].y, vectores[spawnPoint].z), Quaternion.identity);
    //            }
    //        }
    //        else if (indicador > 0.3f && indicador < 0.6f)
    //        {
    //            foreach (int spawn in specialSpawn)
    //            {
    //                if (spawnPoint == spawn)
    //                {
    //                    Instantiate(enemigo1, new Vector3(vectores[spawnPoint].x, vectores[spawnPoint].y, vectores[spawnPoint].z), Quaternion.identity);
    //                }
    //                else
    //                {
    //                    verificador++;
    //                }
    //            }
    //            if (verificador == specialSpawn.Length)
    //            {
    //                verificador = 0;
    //                Instantiate(enemigo3, new Vector3(vectores[spawnPoint].x, vectores[spawnPoint].y, vectores[spawnPoint].z), Quaternion.identity);
    //            }
    //        }
    //        else
    //        {
    //            foreach (int spawn in specialSpawn)
    //            {
    //                if (spawnPoint == spawn)
    //                {
    //                    Instantiate(enemigo2, new Vector3(vectores[spawnPoint].x, vectores[spawnPoint].y, vectores[spawnPoint].z), Quaternion.identity);
    //                }
    //                else
    //                {
    //                    verificador++;
    //                }
    //            }
    //            if (verificador == specialSpawn.Length)
    //            {
    //                verificador = 0;
    //                Instantiate(enemigo3, new Vector3(vectores[spawnPoint].x, vectores[spawnPoint].y, vectores[spawnPoint].z), Quaternion.identity);
    //            }
    //        }
    //    }
    //}

    private void InstanciacionProcedimental()
    {
        int indicador = Random.Range(0, vectores.Length);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < cantidadEnemigos)
        {
            if (Random.Range(0f,1f) >= 0.5f)
            {
                Instantiate(enemigo3, new Vector3(vectores[indicador].x, vectores[indicador].y, vectores[indicador].z), Quaternion.identity);
            }
            else if (Random.Range(0f,1f) >= 0.5f)
            {
                Instantiate(enemigo2, new Vector3(vectores[indicador].x, vectores[indicador].y, vectores[indicador].z), Quaternion.identity);
            }
            else
            {
                Instantiate(enemigo1, new Vector3(vectores[indicador].x, vectores[indicador].y, vectores[indicador].z), Quaternion.identity);
            }
        }
    }
}
