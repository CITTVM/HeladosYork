using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	//referencia al script del jugador
	public ControlPlayer controlPlayer;
	// Use this for initialization

	//controlar la textura del player
	public Texture playerHealthTexture;

	//variables 
	public float screenPositionX;
	public float screenPositionY;

	public float iconSizeX = 25;
	public float iconSizeY = 25;

	//iniciara con 3 health
	public int playerHealth = 5;





	//para quitar health
	void OnGUI(){
		for(int h = 0; h < playerHealth; h++) {
			GUI.DrawTexture(new Rect(screenPositionX + (h * iconSizeX), screenPositionY, iconSizeX, iconSizeY), playerHealthTexture, ScaleMode.ScaleToFit, true, 0);
		}

	}
	//metodo del damage 
	void PlayerDamaged(int damage)
	{

		if (playerHealth > 0) {

			playerHealth -= damage;
		}

		if(playerHealth <= 0){
			playerHealth = 0;
			RestartScene();

		}

	}

	//reinicia la escena
	void RestartScene(){

		SceneManager.LoadScene("Test");

	}



}
