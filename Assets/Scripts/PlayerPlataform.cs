using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este sript es para que el player siga a la plataforma cuando esta se mueve
//de lo contrario la plataforma se movera y el player se caera de la misma

public class PlayerPlataform : MonoBehaviour
{

    CharacterController characterController;

    Vector3 groundPos; //Posicion Actual
    Vector3 nextGroundPos; // Ultima posicion

    Vector3 currentPos;//Posicion recalculada

//Variables para detectar si la plataforma se movio 
    string groundName;
    string lastGroundName;

    bool isJump; // si es true el personaje dejara de moverse con la plataforma
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag== "plataform")
        {
            if(characterController.isGrounded)
            {
                
                RaycastHit hit; //Estructura utilizada  para recuperar informacion desde un rayo
                if(Physics.SphereCast(transform.position,characterController.radius,-transform.up,out hit))
                {
                    //Guardamos el objeto con el que estamos colisionando con el raycast osea la plataforma
                    GameObject inGround = hit.collider.gameObject;
                    groundName = inGround.name;
                    groundPos = inGround.transform.position;//Posicion del objeto donde estamos parados


                    //Si la posicion actual no es igual a nuestra ultima posicion y ademas los nombres
                    //son iguales, quiere decir que aun seguimos en la misma plataforma pero esta 
                    //cambio su posicion, osea se movio.
                    if(groundPos != nextGroundPos && groundName == lastGroundName) 
                    {
                        currentPos = Vector3.zero; //Reseteamos la posicion actual
                        currentPos += groundPos - nextGroundPos; // calculamos  la posicion que debera moverse el player
                        // Restando la posicion actual con la ultima posicion se obtiene el valor que la plataforma se movio
                        characterController.Move(currentPos);// agregamos ese valor al movimiento del player para que este
                        // acompañe el movimiento de la plataforma
                    }

                    lastGroundName = groundName;
                    nextGroundPos = groundPos;


                }
            }else if (!characterController.isGrounded && Input.GetButtonDown("Jump")){

                    currentPos = Vector3.zero;
                    nextGroundPos = Vector3.zero;
                    lastGroundName = null;

            }

            //Si la barra espaciadore se preciona y el player no esta en el suelo
            /*if(Input.GetKey(KeyCode.Space))
            {
                if(!characterController.isGrounded)
                {

                    //Se reinicia todos los vectores 
                   
                    //isJump = true;
                //de esta manera el player esta saltando entonces las condicionales no se cumpliran
                //y dejara de seguir las posiciones de la plataforma
                //de lo contrario el player saltaria y seguiria a la plataforma de igual modo

                }
            }*/
           // if(characterController.isGrounded)
            // si el player ya esta tocando el suelo se cambia a false para que en caso
            // de que se suba a otra plataforma o a la misma todo incie otra vez
                                             

        }
    }


    /*private void OnDrawGizmos()
    {
        player = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position.player.height/4.2f);
    }*/

}
