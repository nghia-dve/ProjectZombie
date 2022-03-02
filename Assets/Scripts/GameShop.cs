using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShop : MonoBehaviour
{
    [SerializeField]
    GameObject m47;
    [SerializeField]
    GameObject akm;
    [SerializeField]
    GameObject menuShop;

    public void shop()
    {
        menuShop.SetActive(true);
    }
    public void item1()
    {
        m47.SetActive(true);
        akm.SetActive(false);
        menuShop.SetActive(false);
    }
    public void item2()
    {
        m47.SetActive(false);
        akm.SetActive(true);
        menuShop.SetActive(false);
    }
}
