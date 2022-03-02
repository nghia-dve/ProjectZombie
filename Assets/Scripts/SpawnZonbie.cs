using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnZonbie : MonoBehaviour
{
    [SerializeField]
    private GameConfig gameConfig;
    [HideInInspector]
    public float countZombie = 9;
    [HideInInspector]
    public float score = 0;
    [HideInInspector]
    public float checkCountZombie = 0;
    [SerializeField]
    private GameObject zombie;
    float timeCheck = 1000f;
    [HideInInspector]
    public float audioSourceGameZombie = 0;


    private void Start()
    {
        //Debug.LogWarning(countZombie);

        countZombie = 9;
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 pointSpawn = transform.position;
        pointSpawn.x = Random.Range(-10, 10);
        pointSpawn.z = Random.Range(-7, 7);

        if (checkCountZombie < countZombie || timeCheck == 0)
        {
            timeCheck -= 0.1f;
            Instantiate(zombie, pointSpawn, Quaternion.identity);
            checkCountZombie++;
            //Debug.LogWarning(countZombie);
            timeCheck = 1000f;
        }
    }
}
