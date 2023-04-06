using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{   
    public GameObject settingsInte;
    
    public void SettingsInterface(){
        settingsInte.transform.Find("Panel").gameObject.SetActive(true);
        
    }



}
