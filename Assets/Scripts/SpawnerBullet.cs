using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    PlayerContronl playerContronl;
    //float timeCheckSpawnBullet = 0.02f;
    [SerializeField]
    GameObject playerSpawn;
    AudioSource audioSource;
    float timeCheck = 0.5f;
    [SerializeField]
    GameObject texTutorial;
    [SerializeField]
    SpawnZonbie spawnZonbie;
    //float timeCheck1 = 1.5f;
    // Start is called before the first frame update
    private void Start()
    {
        audioSource = playerSpawn.GetComponent<AudioSource>();
    }
    private void Update()
    {
        /*if (spawnZonbie.tutorial == 1)
        {
            texTutorial.SetActive(false);
        }*/
        /*if (Input.GetButtonDown("Fire1"))
        {
            if (playerContronl.move.z == 0)
            {
                playerContronl.animatorPlayerShooter.SetBool("isShooter", true);
            }
            else
                if (playerContronl.move.z != 0)
            {
                playerContronl.animatorPlayerShooter.SetBool("isRunShooter", true);
            }
        }
        else
        {
            playerContronl.animatorPlayerShooter.SetBool("isShooter", false);
            playerContronl.animatorPlayerShooter.SetBool("isRunShooter", false);

        }
        if (playerContronl.animatorPlayerShooter.GetBool("isShooter") == true || playerContronl.animatorPlayerShooter.GetBool("isRunShooter") == true)
        {
            timeCheckSpawnBullet -= Time.deltaTime;
            *//*if (timeCheckSpawnBullet < 0)
            {*//*
            Vector3 temp = transform.position;
            Instantiate(bullet, temp, transform.rotation);
            timeCheckSpawnBullet = 0.02f;
            *//*}*//*

        }*/

        timeCheck -= Time.deltaTime;
        if (timeCheck < 0)
        {
            /*audioSource.time = 0;
            audioSource.Stop();*/
            playerContronl.animatorPlayerShooter.SetBool("isShooter", false);
            playerContronl.animatorPlayerShooter.SetBool("isRunShooter", false);
            timeCheck = 0.5f;
        }
        /*timeCheck1 -= 0.1f;
        if (timeCheck1 < 0)
        {
            audioSource.Pause();
            timeCheck1 = 1.5f;
        }*/



    }
    public void Attack()
    {
        texTutorial.SetActive(false);
        if (playerContronl.move.z == 0)
        {
            playerContronl.animatorPlayerShooter.SetBool("isShooter", true);
        }
        else
                if (playerContronl.move.z != 0)
        {
            playerContronl.animatorPlayerShooter.SetBool("isRunShooter", true);
        }
        if (playerContronl.animatorPlayerShooter.GetBool("isShooter") == true || playerContronl.animatorPlayerShooter.GetBool("isRunShooter") == true)
        {
            //audioSource.Play();
            Instantiate(bullet, playerSpawn.transform.position, playerSpawn.transform.rotation);


        }


    }
}
