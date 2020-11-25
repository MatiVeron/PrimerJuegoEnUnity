using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public float playerSpeed;
    private  Vector3 playerInput;
    public CharacterController player;
    private Vector3 movePlayer;

  
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    public float gravity = 9.8f;
    public float velCaida;
    public float jumpForce;
    //Animaciones
    public Animator animator;

    private bool saltando;

    //Score
    public Text puntos;
    private int contadorPts;









    // Start is called before the first frame update
    void Start()
    {
        //Obtengo el componente del personaje controller
        player = GetComponent<CharacterController>();
        animator= GetComponent<Animator>();
        contadorPts = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        //Obtengo los imput que ingresa el player
        horizontalMove= Input.GetAxis("Horizontal");
        verticalMove= Input.GetAxis("Vertical");
        //Genero un vector con esos imputs
        playerInput = new Vector3(horizontalMove,0,verticalMove);
        // ClampMagnitude nos permite establecer un limite para el imput en este caso entre 0 y 1
        playerInput = Vector3.ClampMagnitude(playerInput,1);
        //La funcion camaraDirection se ejecuta para saber a que lugar apunta la camara
        CameraDirection();

        //guardamos en una variable el imput en el eje x multiplicado cuando la camara apunta a la derecha
        //sumado a la fuerza del imput hacia la posicion hacia adelante
        movePlayer = playerInput.x*camRight + playerInput.z * camForward;

        //Posicionamos al player para que mire a la direccion en donde se va a mover
        player.transform.LookAt(player.transform.position + movePlayer);

        setGravity();

        saltar();

   


        //movemos el player 
        player.Move(movePlayer*playerSpeed*Time.deltaTime);    

        if(horizontalMove != 0 || verticalMove != 0){
            animator.SetInteger("anim",1);
        }else{
            animator.SetInteger("anim",0);
        }

        if (saltando){
            /*Input.GetButtonDown("Jump") && player.isGrounded == false*/

            animator.SetInteger("anim",2);
            saltando = false;
        }

        
        
    }

    //Obtener la direccion de la camara
    void CameraDirection()
    {
        //direccion cuando la camara apunta hacia el frente
        camForward = mainCamera.transform.forward ;
        //direccion cuando la camara apunta hacia la derecha
        camRight = mainCamera.transform.right;
        //Evita que el personaje rote hacia arriba
        camForward.y = 0;
        camRight.y = 0;

        //obtenemos las posiciones normalizadas de esa direccion
        camForward = camForward.normalized;
        camRight = camRight.normalized;




    }


//Seteo de la gravedad
    void setGravity(){
        if(player.isGrounded)
        {
            velCaida= -gravity * Time.deltaTime;
            movePlayer.y= velCaida;

        }else{

            velCaida -= gravity * Time.deltaTime;
            movePlayer.y = velCaida;

        }
    }


//Metodo para saltar
        public void saltar()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {

            velCaida = jumpForce;
            movePlayer.y = velCaida;
            saltando = true;

        }

    } 



    public void score()
    {
        contadorPts += 10;
        puntos.text = "SCORE:" + contadorPts;
    }



    

}
