using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControlZombile : MonoBehaviour
{
    [SerializeField]
    float speeBullet = 2f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speeBullet * Time.deltaTime);
        Destroy(gameObject, 1.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
