using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Items : MonoBehaviour
{


    public int damage;
    public int health;

    float tiempoItem = 20f ;


     
    public AudioClip audioScore;
    public AudioClip audioHealth;
    public AudioClip audioDamage;
    


    public Vector3 anglesRotation = new Vector3(15,30,45);
    // Start is called before the first frame update
    void Start()
    {

       //audioDamage = GetComponent<AudioSource>();
       //fuente = GetComponent<AudioSource>();
       //audioHealth = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(anglesRotation*Time.deltaTime);
        
    }


       public void OnTriggerEnter(Collider col)
        {   

        if(col.gameObject.tag == "Player")
        {
            string tagItem;
            tagItem = gameObject.tag;
            switch (tagItem)
            { 
                case "itemScore":
                    
                
                    PlayerController pl = col.GetComponent<PlayerController>();
                    pl.score();
                    
                    
                    AudioSource.PlayClipAtPoint(audioScore,Camera.main.transform.position);

                    Destroy (gameObject);
                    
                    break;
                
                case "itemDamage":
                    
                    Health h = col.GetComponent<Health>();
                    h.health -= damage;
                    
                    AudioSource.PlayClipAtPoint(audioDamage,Camera.main.transform.position);
                    Destroy (gameObject);
                    break;
                
                case "itemHealth":
                    
                    Health he = col.GetComponent<Health>();
                    if(he.health < 100)
                    {
                        he.health += health;
                    }
                    AudioSource.PlayClipAtPoint(audioHealth,Camera.main.transform.position);
                    Destroy (gameObject);
                    break;  
                
                 case "itemTime":

                    Timer t = GameObject.Find("Canvas/Timer").GetComponent<Timer>(); 
                    t.tiempo += tiempoItem;
                    
                    Destroy (gameObject);
                    break;      
 
                        
            }
    

        }
    }





}
