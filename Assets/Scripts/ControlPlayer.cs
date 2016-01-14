using UnityEngine;
using System.Collections;

public class ControlPlayer : MonoBehaviour
{

	//Variables Movimiento
	public float Velocidad=15;
	public float Salto=25;
	float moveVelocity;


<<<<<<< HEAD
	//daño que tomara el player
	float takenDamage= 0.2f;
=======

	//takendamage
	float takenDamage = 0.2f;

	#region Barra de Hidratacion
	public RectTransform HidroTransform;
	private float almacenadaY;
	private float minXValue;
	private float maxXValue;
	private int hidratacionActual;
	public int MaxHidratacion;
	#endregion
>>>>>>> origin/master

	//Variables enSuelo
	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	public float comprobadorRadio = 1.0f;
	public LayerMask mascaraSuelo;

<<<<<<< HEAD
=======
	void Start(){
		#region Barra de Hidratacion
		almacenadaY = HidroTransform.position.y;
		maxXValue = HidroTransform.position.x;
		minXValue = HidroTransform.position.x - HidroTransform.rect.width;
		setHidratacionActual(MaxHidratacion);
		#endregion
	}
>>>>>>> origin/master

	void FixedUpdate(){
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
	}


	void Update ()
	{
		//Salto
		if (enSuelo && Input.GetKeyDown (KeyCode.Space))
		    {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, Salto);
			}

		//Movimiento derecha izquierda
		moveVelocity = 0;
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			moveVelocity = -Velocidad;
		}
		if (Input.GetKey (KeyCode.RightArrow))
		{
			moveVelocity = Velocidad;
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

		#region Barra de Hidratacion
		if (hidratacionActual >= 0) {
			//HidratacionActual = (int)(HidratacionActual - (1 * Time.deltaTime));
			setHidratacionActual((int)(getHidratacionActual() - (0.9f * Time.deltaTime)));
		}
		#endregion
	}
<<<<<<< HEAD
=======

	//Chequear ensuelo
	void OnTriggerEnter2D()
	{
		enSuelo = true;
	}
	void OnTriggerExit2D()
	{
		enSuelo = false;
	}
>>>>>>> origin/master


	// para el DAÑO AL JUGADOR
	public IEnumerator TakenDamage(){
		GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(takenDamage);
		GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds(takenDamage);
		GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(takenDamage);
		GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds(takenDamage);
		GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(takenDamage);
		GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds(takenDamage);
	}
<<<<<<< HEAD




=======
	#region Barra de Hidratacion	
	private void ManejoHidratacion(){
		float ValorXActual = MapeoValores (getHidratacionActual(), 0, MaxHidratacion, minXValue, maxXValue);
		HidroTransform.position = new Vector2 (ValorXActual, almacenadaY);
	}

	private float MapeoValores(float x, float inMin, float inMax, float outMin, float outMax){
		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}

	/*private int HidratacionActual{
		get { return HidratacionActual;}
		set { 
			HidratacionActual = value;
			ManejoHidratacion ();
		}
	}*/

	private void setHidratacionActual(int value){
		hidratacionActual = value;
		ManejoHidratacion ();
	}
	private int getHidratacionActual(){
		return hidratacionActual;
	}
	#endregion
>>>>>>> origin/master
}