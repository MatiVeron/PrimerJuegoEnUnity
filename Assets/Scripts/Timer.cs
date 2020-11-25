using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
 public Text contador;
 public float tiempo;

 void Start()
 {
      contador.text = " "+ tiempo;
 }


void Update()
{
    tiempo-= Time.deltaTime;
    contador.text = " "+tiempo.ToString("f0");

    if(tiempo <= 0)
    {
        contador.text = "0";
        Debug.Log("tiempo agotado");
        SceneManager.LoadScene("GameOver");
        
    
    }
    
}




public void startTimer (float tiempo)
{
    contador.text = " "+ tiempo;


}

public void actualizarTimer()
{
    tiempo-= Time.deltaTime;
    contador.text = " "+tiempo.ToString("f0");
}

public void stopTimer(float tiempo)
{
    if(tiempo <= 0)
    {
        contador.text = "0";
        Debug.Log("tiempo agotado");

    
    }
}    


public void setTime(float time)
{
    this.tiempo = time;
}
    
}
