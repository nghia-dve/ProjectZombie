using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieControl : MonoBehaviour
{
    [SerializeField]
    private float hp = 1f;
    [SerializeField]
    private List<GameObject> point = new List<GameObject>();
    private GameObject player;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject spawnBullet;
    [SerializeField]
    SpawnZonbie spawnZonbie;
    /*[SerializeField]
    GameManager gameManager;*/
    AudioSource audioSource;

    [HideInInspector]
    public float score = 0;

    bool checkZombile;
    float zombileSpeed = 0.9f;
    float timeCheck = 0.7f;
    float timeCheck1 = 0.7f;
    float timeCheck2 = 0.2f;
    int index = 0;
    public Scrollbar currentScore;

    private Animator animatorZombile;
    private void Start()
    {
        animatorZombile = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("checkZombie");
        audioSource = gameObject.GetComponent<AudioSource>();
        spawnZonbie.audioSourceGameZombie = audioSource.volume;
        score = spawnZonbie.countZombie;
    }

    private void Update()
    {

        audioSource.volume = spawnZonbie.audioSourceGameZombie;
        /*if (Mathf.Abs(transform.position.x - zombile.transform.position.x) < 1.5f && Mathf.Abs(transform.position.y - zombile.transform.position.y) < 1.5f && Mathf.Abs(transform.position.z - zombile.transform.position.z) < 1.5f)
        {
            checkZombile = true;
        }
        else
        {
            checkZombile = false;
        }*/
        if (checkZombile)
        {
            //transform.Translate(Vector3.forward * Time.deltaTime);
            timeCheck2 -= Time.deltaTime;
            if (timeCheck2 < 0)
            {
                checkZombile = false;
                timeCheck2 = Random.Range(0.4f, 0.7f);
            }

        }
        if ((Mathf.Abs(transform.position.x - player.transform.position.x) < 2f && Mathf.Abs(transform.position.y - player.transform.position.y) < 2f && Mathf.Abs(transform.position.z - player.transform.position.z) < 2f) && checkZombile == false)
        {
            //audioSource.Play();
            transform.LookAt(player.transform.position);

            animatorZombile.SetBool("isAttack", false);
            animatorZombile.SetBool("isWalk", true);

            if (Mathf.Abs(transform.position.x - player.transform.position.x) < 0.5f && Mathf.Abs(transform.position.y - player.transform.position.y) < 0.5f && Mathf.Abs(transform.position.z - player.transform.position.z) < 0.5f)
            {
                //audioSource.Play();
                animatorZombile.SetBool("isWalk", false);
                animatorZombile.SetBool("isAttack", true);

                timeCheck1 = 0.7f;
                transform.Translate(Vector3.forward * 0 * Time.deltaTime);
                Vector3 temp = spawnBullet.transform.position;
                timeCheck -= Time.deltaTime;
                if (timeCheck < 0)
                {
                    audioSource.Play();
                    timeCheck = 0.7f;
                    Instantiate(bullet, temp, spawnBullet.transform.rotation);
                }
            }
            else
            {
                audioSource.Stop();
                //audioSource.Play();
                transform.Translate(Vector3.forward * zombileSpeed * Time.deltaTime);
            }

        }
        else
        {
            animatorZombile.SetBool("isAttack", false);
            animatorZombile.SetBool("isWalk", true);
            if (Mathf.Abs(transform.position.x - point[index].transform.position.x) < 0.4f && Mathf.Abs(transform.position.y - point[index].transform.position.y) < 0.4f && Mathf.Abs(transform.position.z - point[index].transform.position.z) < 0.4f)
            {
                index = Random.Range(1, point.Count - 1);
            }
            timeCheck1 -= Time.deltaTime;
            if (timeCheck1 < 0.2f)
            {
                transform.LookAt(point[index].transform.position);
            }
            transform.Translate(Vector3.forward * zombileSpeed * Time.deltaTime);
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "zombile")
        {*/

        //}
        if (other.gameObject.tag == "Bullet")
        {

            //GameManager.Instance.CollectItem(hp);
            hp -= 0.2f;
            if (hp <= 0)
            {
                spawnZonbie.countZombie--;
                spawnZonbie.score++;
                //Debug.LogWarning(gameManager.zombileCount);
                gameObject.SetActive(false);


            }

            //Debug.Log(hp);
            currentScore.size = hp;
            if (hp <= 0)
            {
                currentScore.gameObject.SetActive(false);

                //Destroy(currentScore);
                //score++;

            }
        }
        /*if (other.gameObject.tag != "Bullet" || other.gameObject.tag != "Player")
        {
            checkZombile = true;
            Debug.LogWarning("dv");
        }*/
        if (other.gameObject.CompareTag("zombie"))
        {
            checkZombile = true;

        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "zombie")
        {
            checkZombile = true;

        }
    }
    /* private void OnTriggerExit(Collider other)
     {
         if (other.gameObject.tag == "zombile")
         {
             checkZombile = false;
         }

     }*/

}
