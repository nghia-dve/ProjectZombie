using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContronl : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;
    private Animator animatorPlayer;
    [HideInInspector]
    public Animator animatorPlayerShooter;
    [SerializeField]
    Text textTutorial;
    public float hpPlayer = 100f;
    [SerializeField]
    private Scrollbar scrollbar;
    [SerializeField]
    Text text;
    [SerializeField]
    Image image;
    [SerializeField]
    FixedJoystick joystick;
    [HideInInspector]
    public Vector3 ofsetPlayer;
    float timeCheck = 0.2f;
    [SerializeField]
    GameOver gameOver;
    [SerializeField]
    SpawnZonbie spawnZonbie;


    // Start is called before the first frame update
    void Start()
    {

        //Debug.Log(ofsetPlayer);
        animatorPlayerShooter = GetComponent<Animator>();
        animatorPlayer = GetComponent<Animator>();
    }
    private void Awake()
    {
        ofsetPlayer = transform.position;
        /*        Debug.Log(ofsetPlayer);*/
    }
    private float x = 0;
    private float z = 0;
    [HideInInspector]
    public Vector3 move;
    Vector3 vector;

    // Update is called once per frame
    void Update()
    {
        z = joystick.Vertical;
        x = joystick.Horizontal;
        timeCheck -= Time.deltaTime;
        if (timeCheck < 0)
        {
            image.gameObject.SetActive(false);
        }
        move = new Vector3(x, transform.position.y, z);
        if (move.z != 0)
        {
            animatorPlayer.SetBool("isRun", true);


        }
        if (move.z == 0)
        {
            animatorPlayer.SetBool("isRun", false);

        }



        characterController.Move(move * Time.deltaTime);



        /*Vector3 rotation = Camera.main.WorldToScreenPoint(joystick.transform.position) - transform.position;
        rotationY = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(rotationY - 90, Vector3.down);*/
        if (joystick.Vertical != 0 || joystick.Horizontal != 0)
        {
            vector = new Vector3(joystick.Horizontal, transform.position.y, joystick.Vertical);
            textTutorial.gameObject.SetActive(false);
            //spawnZonbie.tutorial = 1;

        }

        //transform.LookAt(move);
        transform.rotation = Quaternion.LookRotation(vector);

        //Debug.LogWarning(gameOver.tutorial);
        /*if (spawnZonbie.tutorial == 1)
        {

            textTutorial.gameObject.SetActive(false);
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bulletZombile")
        {
            if (hpPlayer > 0)
            {
                hpPlayer--;
                text.text = hpPlayer.ToString();
                scrollbar.size -= 0.01f;
            }
            else
            {
                scrollbar.gameObject.SetActive(false);

            }
            if (hpPlayer > 0)
            {
                image.gameObject.SetActive(true);
            }

            timeCheck = 0.2f;
        }
    }
}
