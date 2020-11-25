using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    public int velocidad;
    public Animator animator;
    public float velocidadCorrer=10.0f;
    public float velocidadRotacion=10.0f;
    


    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float traslacion= Input.GetAxis("Vertical") * velocidadCorrer;
        float rotacion = Input.GetAxis("Horizontal")*velocidadRotacion;
        transform.Translate(0,0,traslacion);
        transform.Translate(0,0,rotacion);
        
        if (Input.GetButtonDown("Jump")){

            animator.SetTrigger("isJump");
        }
        if (traslacion !=0){

            animator.SetBool("isWalk",true);

        }else{
            animator.SetBool("isWalk",false);
        }
        

        
        //transform.Translate(Input.GetAxis("Horizontal")*velocidad*Time.deltaTime,Input.GetAxis("Vertical")*velocidad*Time.deltaTime,0);
    }

}