using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    PlayerContronl playerContronl;
    [SerializeField]
    Button gameOver;
    [SerializeField]
    Joystick joystick;
    [SerializeField]
    Button buttonAttack;
    [SerializeField]
    Scrollbar scrollbarHpPlayer;
    [SerializeField]
    Text textHpPlayer;
    /*[SerializeField]
    private List<GameObject> zombile = new List<GameObject>();*/
    [SerializeField]
    GameObject player;
    [SerializeField]
    Button buttonReset;
    [SerializeField]
    private SpawnZonbie spawnZonbie;

    [SerializeField]
    private SpawnZonbie spawnZonbie1;
    [SerializeField]
    Text text;
    [HideInInspector]
    public float tutorial;
    [SerializeField]
    GameObject menuPause;
    //float tutorial1;
    float countZombie = 0;

    // Start is called before the first frame update
    void Start()
    {
        countZombie = spawnZonbie.countZombie;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "score: " + spawnZonbie1.score + " (" + spawnZonbie1.countZombie + "/" + countZombie + ")";

        if (playerContronl.hpPlayer <= 0)
        {
            //Debug.Log("dv");
            gameOver.gameObject.SetActive(true);
            joystick.gameObject.SetActive(false);
            buttonAttack.gameObject.SetActive(false);
            scrollbarHpPlayer.gameObject.SetActive(false);
        }
        else
        if (playerContronl.hpPlayer > 0)
        {
            //Debug.Log("dv");
            joystick.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(false);
            buttonAttack.gameObject.SetActive(true);
            scrollbarHpPlayer.gameObject.SetActive(true);
        }
        if (spawnZonbie1.countZombie <= 0)
        {
            buttonReset.gameObject.SetActive(true);
        }
        else
            if (spawnZonbie1.countZombie > 0)
        {
            buttonReset.gameObject.SetActive(false);
        }

    }
    /*public void _Reset()
    {

        player.transform.position = playerContronl.ofsetPlayer;
        textHpPlayer.text = "100";
        scrollbarHpPlayer.size = 1;
        playerContronl.hpPlayer = 100f;
        *//*for (int i = 0; i < zombile.Count; i++)
        {
            zombile[i].gameObject.SetActive(true);
        }*//*

    }*/
    public void ResetTheGame()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        spawnZonbie1.countZombie = 9;
        //tutorial1 = 1;
    }

}
