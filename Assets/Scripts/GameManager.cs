using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Scrollbar currentScore;
    [HideInInspector]
    //public float zombileCount = 6;
    private static GameManager _instance;
    private float _score = 1;
    public static GameManager Instance => _instance;
    [SerializeField]
    SpawnZonbie spawnZonbie;
    /*[SerializeField]
    Text textScore;
    [HideInInspector]
    public float score1;
    [SerializeField]
    ZombieControl zombieControl;*/
    private void Awake()
    {
        _instance = this;
        //score1 = spawnZonbie.zombies;
    }
    private void Start()
    {

    }
    public void CollectItem(float score)
    {
        this._score -= score;
        currentScore.size = _score;
        //Debug.Log(currentScore.size);
        if (_score <= -1)
        {
            currentScore.gameObject.SetActive(false);
            //Destroy(currentScore);

        }
    }
    public void Update()
    {
        //Debug.LogWarning(zombieControl.score);
        //textScore.text = score1 + "/";
    }
}
