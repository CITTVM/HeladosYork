using UnityEngine;
using System.Collections;

public class Manejo : MonoBehaviour {

	public Manejo manejo;

	//controlar la textura del player
	public Texture playersHealthTexture;

	public float screenPositionX;
	public float screenPositionY;

	public float iconSizeX = 25;
	public float iconSizeY = 25;

	public int playersHealth = 3;



	void OnGUI(){
		for(int h =0; h < playersHealth;h++) {
			GUI.DrawTexture (new Rect (screenPositionX + (h * iconSizeX), screenPositionY, iconSizeX, iconSizeY), playersHealthTexture, ScaleMode.ScaleToFit, true, 0);
		}

	}
	//metodo del damage del enemigo
	void PlayerDamaged(int damage)
	{

		if (playersHealth > 0) {

			playersHealth -= damage;
		}

		if(playersHealth <= 0){
			playersHealth = 0;
			RestartScene();

		}

	}

	void RestartScene(){



	}
}
