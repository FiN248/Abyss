using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalEnding : MonoBehaviour
{
    public void QuitGame(){
        SceneManager.LoadScene("Menu");
    }
}
