using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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




	//PARA EL MOVIL

	public GameObject bullet1;
	public GameObject bullet2;
	public GameObject CanvasInventario;
    SlotInventario slotInventario;
	//PARA EL MOVIL


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
	public AudioSource pisada1;
	public AudioSource pisada2;

    #endregion


    void Start(){
		

		//armas inactivas al empezar
		bullet1.SetActive (false);
		bullet2.SetActive (false);
	
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

		// en android el inventario comienza inactivo
		#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR

		CanvasInventario.active = false;
		#else
		Move (hInput);
		#endif
	}


	void FixedUpdate ()
	{



		if (Input.GetButton("Horizontal") ){
            if (isGrounded)
            {
				if (!pisada1.isPlaying) {
					pisada1.Play ();

				} else if(!pisada2.isPlaying)  {
					pisada2.Play();
				}
            }
		
		}
		//isGrounded = Physics2D.Linecast (myTrans.position, tagGround.position, playerMask);
		isGrounded = Physics2D.OverlapCircle (compSuelo.position, comprobadorRadio, mascaraSuelo);


#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
        Move();
        //Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
		Jump();
#else
		Move (hInput);
#endif


        //LLAMA AL METODO CLICK DE SLOTINVENTARIO
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
        Move();
        //Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("click"))
			slotInventario.click();

#else
		Move (hInput);
#endif
        // PARA MOVER EL MARCADOR, SE LLAMA AL MEDOTO DEL SCRIPT SLOTINVENTARIO
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
        Move();
		//Move(Input.GetAxisRaw("Horizontal"));
		if(Input.GetButtonDown("marcadore"))
			slotInventario.marcadore();
#else
		Move (hInput);
#endif

        // PARA ABRIR EL INVENTARIO
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
        Move();
        //Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("abrirInventario"))
			abrirInventario(); 
	
		#else
		Move (hInput);
		#endif
	}
		//if(Input.GetButtonDown("CambiarArma"))}
			//cambiarArma();
		
	







	void Update ()
	{
		

		#region Barra de Hidratacion
		if (hidratacionActual >= 0) {
			//HidratacionActual = (int)(HidratacionActual - (1 * Time.deltaTime));
			setHidratacionActual((int)(getHidratacionActual() - (0.9f * Time.deltaTime)));
		}
		#endregion
	}

    public void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!canMoveInAir && !isGrounded)
                return;
            transform.Translate(Vector2.right * 4f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!canMoveInAir && !isGrounded)
                return;
            transform.Translate(Vector2.right * 4f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
    //public void Move(float horizonalInput)
    //{
    //	if(!canMoveInAir && !isGrounded)
    //		return;

    //	Vector2 moveVel = myBody.velocity;
    //	moveVel.x = horizonalInput * speed;
    //	myBody.velocity = moveVel;
    //}

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

	//METODOS PARA EL MOVIL




	//abrir inventario

	public void abrirInventario(){
	


CanvasInventario.active = !CanvasInventario.active;

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

