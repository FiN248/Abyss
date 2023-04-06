using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void ContinueGame(){
        SceneManager.LoadScene("demo1");
    }

    public void QuitGame(){
        SceneManager.LoadScene("Menu");
    }
}
