using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    public Rigidbody platformRB;
    public Transform[] platformPositions;
    public float platformSpeed;
    private int actualPosition = 0;
    private int nextPosition = 1;

    public bool moveToTheNext = true;
    public float waitTime;

    void Start()
    {

        platformRB = GetComponent<Rigidbody>();

    }
    
    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    //Metodo para mover plataformas de un punto a otro
    public void MovePlatform()
    {
        if (moveToTheNext)// consulto el bool 
        {
            //Detiene una corutina llamada Wait for move que permite darle un tiempo de espera a la plataforma en un punto
            //Antes de seguir moviendose hacia el otro punto
            StopCoroutine(WaitForMove(0));

            //MovePosition() mueve un cuerpo rigido cinematico hacia un punto

            // MoveTowards () Calcula una posición entre los puntos especificados por current y target, 
            //moviéndose no más allá de la distancia especificada por maxDistanceDelta.
            
            //Movemos el objeto, a una distancia especificada por la posicion inicial del objeto, a la siguiente posicion , 
            //a una velocidad determinada multiplicada por el tiempo (Time.deltaTime)
            platformRB.MovePosition(Vector3.MoveTowards(platformRB.position,platformPositions[nextPosition].position,platformSpeed*Time.deltaTime));
        
        }

        //Ahora averiguamos si la distancia entre los puntos es menor o igual a 0
        //Si es True significa que la plataforma llego a su destino, entonces hay que hacer que vuelva

        if(Vector3.Distance(platformRB.position,platformPositions[nextPosition].position) <= 0)
        {
            //ejecutamos la corutina para saber el tiempo que debe esperar antes de partir 
            //a otro punto
            StartCoroutine(WaitForMove(waitTime));
            //A la posicion actual le asignamos la siguiente posicion
             actualPosition = nextPosition;

             // y a la posicion siguiente le sumamos 1
             nextPosition++;

             //si la  siguiente posicion es mayor que la longitud del array de puntos
             //significa que ya la plataforma recorrio todos los puntos y tiene que volver a
             //a laposicion inicial, osea el array en posicion 0 
            if(nextPosition > platformPositions.Length - 1)
            {
                nextPosition = 0;
            }
        
        }

    }



    //Generar una coroutine para parar la plataforma
    //Una corrutina es una función que tiene la habilidad de pausar su ejecución y devolver 
    //el control a Unity para luego continuar donde lo dejó en el siguiente frame.
    

    IEnumerator WaitForMove(float time)
    {
        //asignamos false para cuando llegue al if donde hay que mover, valide que es falso y se quede en ese punto
        moveToTheNext = false;
        //suspende la corutina cierta cantidad de tiempo antes de largar el retorno de la funcion
        yield return new WaitForSeconds(time);
        //asignamos true para que ahora el if valide que hay que moverse hacia otro punto.
        moveToTheNext = true;
    }

}
