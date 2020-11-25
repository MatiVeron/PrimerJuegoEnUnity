using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
  

  

    
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _timer = 2f;
    //private float timerCount = 0f;
    
    private int _counter;

    [SerializeField]
    private int _maxCounter = 20;

    // Start is called before the first frame update
    void Start()
    {
       
        

        StartCoroutine(FireBullets());
        
    }

    // Update is called once per frame
    void Update()
    {
  
        
    }




    IEnumerator FireBullets()
    {
        Debug.Log("Inicio...");
        //if(isActivate){

            for(int i=0 ;i<_maxCounter;i++)
            {
                _counter++;
                Instantiate(_bullet, transform.position,transform.rotation);
                yield return new WaitForSeconds(_timer);

            }
            Debug.Log ("Fin...");
        //}
    }
}
