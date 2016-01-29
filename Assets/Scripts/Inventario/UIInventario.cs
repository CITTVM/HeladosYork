using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIInventario : MonoBehaviour {

//    public Color[] colorSlots;
//    public Color[] colorIconos;
//
//    [SerializeField]public Imagenes imagenes;
//    [System.Serializable]
//    public class Imagenes
//    {
//        public Image[] slot, icono;
//    }
//    [SerializeField]
//    Iconos iconos;
//    [System.Serializable]public class Iconos {
//        public Sprite pistola, medicina, linterna;
//    }
//    
//
//	
//	private GameObject scriptsContenedor;
//	private JugadorBD jugadorBD;
//    [HideInInspector]public Inventario inventario;
//
//
//
//	// Use this for initialization
//	void Awake () {
//		
//		scriptsContenedor=GameObject.FindGameObjectWithTag ("Scripts");
//		jugadorBD=scriptsContenedor.GetComponent<JugadorBD>();
//        inventario = scriptsContenedor.GetComponent<Inventario>();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		for(int i = 0; i < imagenes.icono.Length; i++)
//        {
//            if(jugadorBD.SlotsBasicos[i] == "Medicina")
//            {
//                imagenes.icono[i].sprite = iconos.medicina;
//                imagenes.icono[i].enabled = true;
//            }
//            if (jugadorBD.SlotsBasicos[i] == "Pistola")
//            {
//                imagenes.icono[i].sprite = iconos.pistola;
//                imagenes.icono[i].enabled = true;
//            }
//            if (jugadorBD.SlotsBasicos[i] == "Linterna")
//            {
//                imagenes.icono[i].sprite = iconos.linterna;
//                imagenes.icono[i].enabled = true;
//            }
//            if (jugadorBD.SlotsBasicos[i] == "")
//            {
//                imagenes.icono[i].enabled = false;
//            }
//        }
//        for(int j = 0; j < imagenes.slot.Length; j++)
//        {
//            if (j == inventario.slotActual)
//            {
//                imagenes.slot[inventario.slotActual].color = colorSlots[0];
//                imagenes.icono[inventario.slotActual].color = colorIconos[0];
//            }
//            else
//            {
//                imagenes.slot[j].color = colorSlots[1];
//                imagenes.icono[j].color = colorIconos[1];
//
//            }
//        }
//	}
}
