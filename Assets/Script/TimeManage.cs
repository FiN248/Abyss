using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManage : MonoBehaviour
{
    public Button setting;
    public Button continueButton;
    public Button Back2MMButtion;
    public GameObject settingsInte;

    public void Pausegame(){
        Time.timeScale = 0;
    }

    public void Resumegame(){
        Time.timeScale = 1;
    }

    private void Start(){
        setting.onClick.AddListener(Pausegame);
        continueButton.onClick.AddListener(Resumegame);
        continueButton.onClick.AddListener(SettingsInterface);
        Back2MMButtion.onClick.AddListener(Resumegame);
    }
    
    
    public void SettingsInterface(){
        settingsInte.transform.Find("Panel").gameObject.SetActive(false);
        
    }
}
