using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public int damage;
    

    private  void OnTriggerEnter( Collider collider)
    {
        if(collider.gameObject.tag == "Player" )
        {
                Health h = collider.GetComponent<Health>();
                h.health -= damage;
           // BarraVida br = collider.GetComponent<BarraVida>();
            //br.vida -= damage;

        }
    }
}
