using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void CargaNivel(string como_jugar) {
        SceneManager.LoadScene(como_jugar);
    }
    public void SALIR() {
        Application.Quit();
    }
}
