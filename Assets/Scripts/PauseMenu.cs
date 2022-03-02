using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    AudioSource audioSourceZombile;
    [SerializeField]

    AudioSource audioSourcePlayer;
    [SerializeField]

    AudioSource audioSourceGround;
    private void Start()
    {


    }
    public void Pause()
    {
        //audioSourceZombile.Stop();
        audioSourcePlayer.Stop();
        audioSourceGround.Stop();
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        audioSourcePlayer.Play();
        audioSourceGround.Play();
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
