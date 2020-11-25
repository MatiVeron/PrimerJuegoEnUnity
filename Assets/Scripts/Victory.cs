using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update
    
    

    private  void OnTriggerEnter( Collider collider)
    {
        if(collider.gameObject.tag == "Player" )
        {
            SceneManager.LoadScene("Victoria");

        }
    }
}
