using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador1 : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private Vector3 moverDireccion;
    public float gravedad = 20.0f;
    public float fuerzaSalto = 10.0f;
    public float velocidad = 20.0f;
    public float veloGiro = 200.0f;
    public float adelante = -20.0f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (controller.isGrounded && Input.GetButton("Vertical"))
        {
            anim.SetInteger("AnimacionPar", 1);
            moverDireccion = transform.forward * Input.GetAxis("Vertical") * adelante;
            float girar = Input.GetAxis("Horizontal");
            transform.Rotate(0, girar * veloGiro * Time.deltaTime, 0);
        }

        else if (controller.isGrounded)
        {
            anim.SetInteger("AnimacionPar", 0);
            moverDireccion = transform.forward * Input.GetAxis("Vertical") * 0;
            float girar = Input.GetAxis("Horizontal");
            transform.Rotate(0, girar * veloGiro * Time.deltaTime, 0);
        }

        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            anim.SetInteger("AnimacionPar", 2);
            moverDireccion.y = fuerzaSalto;
        }



        controller.Move(moverDireccion * Time.deltaTime);
        moverDireccion.y -= gravedad * Time.deltaTime;
    }
}