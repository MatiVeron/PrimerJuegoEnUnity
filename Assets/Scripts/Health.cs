using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public  int health;

    public Slider sliderBarHealth;

    public GameObject _explotionEffect;


    // Update is called once per frame
    void Update()
    {
        sliderBarHealth.value = health;
        if(health<=0)
        {
            Instantiate(_explotionEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);


            SceneManager.LoadSceneAsync("GameOver");



        }

                


        
    }
}
