using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSetting : MonoBehaviour
{

    [SerializeField]
    GameObject menuSetting;
    [SerializeField]
    Slider sliderAudioBackGround;
    [SerializeField]
    Slider sliderAudioGun;
    [SerializeField]
    Slider sliderAudioZombie;
    [SerializeField]
    AudioSource audioSourceBackGround;
    [SerializeField]
    AudioSource audioSourceGun;
    [SerializeField]
    SpawnZonbie spawnZonbie;


    private void Start()
    {
        //sliderAudioBackGround.value = audioSourceBackGround.volume;
    }
    public void Setting()
    {
        sliderAudioZombie.value = spawnZonbie.audioSourceGameZombie;
        menuSetting.SetActive(true);
        sliderAudioGun.value = audioSourceGun.volume;
        sliderAudioBackGround.value = audioSourceBackGround.volume;
    }
    public void Done()
    {
        audioSourceBackGround.volume = sliderAudioBackGround.value;

        audioSourceGun.volume = sliderAudioGun.value;
        spawnZonbie.audioSourceGameZombie = sliderAudioZombie.value;
        menuSetting.SetActive(false);
    }

}
