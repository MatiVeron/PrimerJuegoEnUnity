using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
/*metodo Awake() es siempre
Metodo Start() es Inicia Primero
Metodo Update() Actualiza Posición por Fotograma
Metodo FixedUpdate() Actualiza Posición por Fotograma con Físicas de 
Gravedad RigidBody

Vector3 controla la posicion de un objeto en 3 Dimensiones x, y, z.
GetAxis Controla las 4 teclas de Movimiento en flechas o WASD
Gekey Agregas una tecla especifica
Se pueden declarar variables fuera de los métodos con Acceso Public o Private.*/
    
    public GameObject player;
    private Vector3 PosicionRelativa;
    [Range (0.1f,1.0f)] public float Smooth;
    public bool rotacionActiva = true;
    public float velocidadRotacion = 5.0f; 
    public bool lookAtPlayer = false;




    // Start is called before the first frame update
    void Start()
    {
        // Resto la posicion del objeto actual(camara) la posicion del objeto jugador
        //Obtengo una posicion relativa
        PosicionRelativa = transform.position - player.transform.position;  
       
    }

    // Update is called once per frame
    void Update()
    {
        //Al objeto actual (camara) le asigno la posicion del jugador mas la posicion relativa
        //De esta manera en cada frame cada vez que el jugador se mueva la camara lo seguira
        if(rotacionActiva){
            Quaternion AnguloCamra = Quaternion.AngleAxis (Input.GetAxis("Mouse X")*velocidadRotacion,Vector3.up);   
            PosicionRelativa = AnguloCamra * PosicionRelativa;

        }
         
        Vector3 nuevaPosicion = player.transform.position + PosicionRelativa;
        transform.position = Vector3.Lerp (transform.position,nuevaPosicion,Smooth);


       if(lookAtPlayer || rotacionActiva)
       {
          transform.LookAt(player.transform) ;

       }

        
        

        
    }



}
