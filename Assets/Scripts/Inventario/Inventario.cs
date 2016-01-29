using UnityEngine;
using System.Collections;

public class Inventario : MonoBehaviour {

//    private Transform player;
//    public int slotActual;
    public Transform inicioRayCast;
	private GameObject scriptsContenedor;
	private NombresObjetosBD nombreObjetos;
//	private JugadorBD jugadorBD;
//	private RaycastHit hit;
//    private bool haySlotsVacios;
//    [SerializeField]
//    public Objetos objetos;
//    [System.Serializable]public class Objetos
//    {
//        public GameObject pistola, medicina, linterna;
//    }


	// Use this for initialization
	void Awake () {
		scriptsContenedor=GameObject.FindGameObjectWithTag ("Scripts");
		nombreObjetos=scriptsContenedor.GetComponent<NombresObjetosBD>();
//		jugadorBD=scriptsContenedor.GetComponent<JugadorBD>();
//        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {



		RaycastHit hit;

			       
	if(Physics.Raycast (inicioRayCast.position,Vector3.forward,out hit)){
if(Input.GetKey (KeyCode.E)){
for(int i=0;i<nombreObjetos.itemsString.Length;i++){
if(hit.collider.CompareTag(nombreObjetos.itemsString[i])){
Destroy (hit.collider.gameObject);

//        if (Input.GetKeyDown(KeyCode.Q))
//            Drop();
//        NavegacionInventario();
//		Debug.DrawRay(inicioRayCast.position,inicioRayCast.forward,Color.blue);
//		//----------Busca si estoy recogiendo el objeto correcto	
//		if(Physics.Raycast (inicioRayCast.position,inicioRayCast.forward,out hit)){
//			if(Input.GetKey (KeyCode.E)){
//				for(int i=0;i<nombreObjetos.itemsString.Length;i++){
//					if(hit.collider.CompareTag(nombreObjetos.itemsString[i])){
//						RecogerItem ();
//
//					}
//				}
//			}
//		}
		//------------------------------------------------
					}}}}}
//	void RecogerItem(){
//		for(int i=0;i<jugadorBD.SlotsBasicos.Length;i++){
//			if(jugadorBD.SlotsBasicos[i]==""){
//                haySlotsVacios = true;
//				break;
//            }
//		}
//        for(int i=slotActual;i<=jugadorBD.SlotsBasicos.Length; i++)
//        {
//            if (haySlotsVacios)
//            {
//                if (i == jugadorBD.SlotsBasicos.Length)
//                {
//                    i = -1;
//                }else if (jugadorBD.SlotsBasicos[i]=="")
//                {
//                    jugadorBD.SlotsBasicos[i] = hit.collider.tag;
//                    Destroy(hit.collider.gameObject);
//                    haySlotsVacios=false;
//                    return;
//                }
//            }else
//            {
//                return;
//            }
//        }
//    }
//    void NavegacionInventario()
//    {
//        if(Input.GetAxisRaw("Mouse ScrollWheel") < 0)
//        {
//            if (slotActual < jugadorBD.SlotsBasicos.Length - 1)
//                slotActual++;
//            else
//                slotActual = 0;
//        }
//        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0)
//        {
//            if (slotActual > 0)
//                slotActual--;
//            else
//                slotActual = jugadorBD.SlotsBasicos.Length - 1;   
//        }
//
//    }
//    void Drop()
//    {
//        if (jugadorBD.SlotsBasicos[slotActual] == "Pistola")
//        {
//            GameObject cloneObjeto = Instantiate(objetos.pistola, player.position + player.forward, Quaternion.identity) as GameObject;
//            cloneObjeto.GetComponent<Rigidbody>().AddForce(player.forward * 1000);
//            jugadorBD.SlotsBasicos[slotActual] = "";
//        }
//        if (jugadorBD.SlotsBasicos[slotActual] == "Linterna")
//        {
//            GameObject cloneObjeto = Instantiate(objetos.linterna, player.position + player.forward, Quaternion.identity) as GameObject;
//            cloneObjeto.GetComponent<Rigidbody>().AddForce(player.forward * 1000);
//            jugadorBD.SlotsBasicos[slotActual] = "";
//        }
//        if (jugadorBD.SlotsBasicos[slotActual] == "Medicina")
//        {
//            GameObject cloneObjeto = Instantiate(objetos.medicina, player.position + player.forward, Quaternion.identity) as GameObject;
//            cloneObjeto.GetComponent<Rigidbody>().AddForce(player.forward * 1000);
//            jugadorBD.SlotsBasicos[slotActual] = "";
//        }
//
//    }
}
