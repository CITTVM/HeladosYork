using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotInventario : MonoBehaviour {
//
	public int ID;
	public Image Child;
	public marcador Marcador;
    public JugadorInventario Inventario;
    public Text cantidad;
//
	public void click(){


	if (Inventario.Objetos[ID].Objeto != null)
		{

			if (Marcador.ID != ID)
		{
			Marcador.transform.position = transform.position;
			Marcador.ID = ID;
		} 

			else
			{

				Inventario.Usar(ID);
			}
         }
	}

	void Update(){
//
		Child.sprite = Inventario.Objetos[ID].sprite;
     	cantidad.text = Inventario.Cantidad[ID].ToString();
	}
//



}
