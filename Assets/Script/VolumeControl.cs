using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource bgmAudio;
    public Slider volumeSlider;

    public void Update(){
        bgmAudio.volume = volumeSlider.value;
    }
}
