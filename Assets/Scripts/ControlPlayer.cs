using UnityEngine;
using System.Collections;

public class ControlPlayer : MonoBehaviour
{



	public float speed = 15, jumpVelocity = 40;
	public LayerMask playerMask;
	public bool canMoveInAir = true;
	//Transform myTrans, tagGround;
	Rigidbody2D myBody;
	public bool isGrounded = false;
	float hInput = 0;


	public Transform compSuelo;
	float comprobadorRadio =0.03f;
	public LayerMask mascaraSuelo;

	public GameObject weapon01;
	public GameObject weapon02;
	public Rigidbody2D bullet1;
	public Rigidbody2D bullet2;


	//daño que tomara el player
	float takenDamage= 0.2f;


	//takendamage
	//float takenDamage = 0.2f;

	#region Barra de Hidratacion
	public RectTransform HidroTransform;
	private float almacenadaY;
	private float minXValue;
	private float maxXValue;
	private int hidratacionActual;
	public int MaxHidratacion;
    #endregion

    #region Sound Effects
    public AudioSource salto;
    public AudioSource aterrizar;
    #endregion





    void Start(){
		#region Barra de Hidratacion
		almacenadaY = HidroTransform.position.y;
		maxXValue = HidroTransform.position.x;
		minXValue = HidroTransform.position.x - HidroTransform.rect.width;
		setHidratacionActual(MaxHidratacion);
		#endregion

		myBody = this.GetComponent<Rigidbody2D>();
		//myTrans = this.GetComponent<Transform>();
		//myTrans = this.transform;
		//tagGround = GameObject.Find (this.name + "tag_ground").transform;

	}


	void FixedUpdate ()
	{
		//isGrounded = Physics2D.Linecast (myTrans.position, tagGround.position, playerMask);
		isGrounded = Physics2D.OverlapCircle (compSuelo.position, comprobadorRadio, mascaraSuelo);


		#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR

		Move(Input.GetAxisRaw("Horizontal"));
		if(Input.GetButtonDown("Jump"))
		Jump();
#else
		Move (hInput);
#endif
        


		#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR

		Move(Input.GetAxisRaw("Horizontal"));
		if(Input.GetButtonDown("CambiarArma"))
			cambiarArma();
		#else
		Move (hInput);
		#endif
	}







	void Update ()
	{
		

		#region Barra de Hidratacion
		if (hidratacionActual >= 0) {
			//HidratacionActual = (int)(HidratacionActual - (1 * Time.deltaTime));
			setHidratacionActual((int)(getHidratacionActual() - (0.9f * Time.deltaTime)));
		}
		#endregion
	}

	public void Move(float horizonalInput)
	{
		if(!canMoveInAir && !isGrounded)
			return;

		Vector2 moveVel = myBody.velocity;
		moveVel.x = horizonalInput * speed;
		myBody.velocity = moveVel;
	}

	public void Jump()
	{
        if (isGrounded)
        {
            myBody.velocity += jumpVelocity * Vector2.up;
            salto.Play();
        }
	}

	public void StartMoving(float horizonalInput)
	{
		hInput = horizonalInput;
	}

	public void cambiarArma()
	{
//		weapon02.SetActive(true);
//		weapon01.SetActive(true);


		if (weapon01.activeSelf){
			weapon01.SetActive(false);
			weapon02.SetActive(true);





			//weapon03.SetActive(true);
		}
		else{
			weapon01.SetActive(true);
			weapon02.SetActive(false);
			//weapon02.SetActive(true);

		}
	
	}










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



	// DESTRUIR HELADO SI COLISIONA CON EL
	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.gameObject.tag == "Helado") {

			Destroy (col.gameObject);

		}
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Soil")
        {
            aterrizar.Play();
        }
    }
}