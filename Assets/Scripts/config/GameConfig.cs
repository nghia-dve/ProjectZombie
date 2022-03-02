using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/Game")]
public class GameConfig : ScriptableObject
{
    public List<GameObject> gun = new List<GameObject>();

    public float coin = 0;
    public float numberZombie;

}