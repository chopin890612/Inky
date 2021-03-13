using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DouduckGame;

public class MainController : MonoBehaviour
{

    public GameObject shopUI;
    public GameObject shopBut;
    public GameObject startBut;
    void Start()
    {
        shopUI.SetActive(false);
    }
    public void ShopUI()
    {
        shopUI.SetActive(true);
        shopBut.SetActive(false);
        startBut.SetActive(false);
        DouduckGameCore.GetSystem<DataSystem>().DataLoad();
    }
    public void BackButton()
    {
        DouduckGameCore.GetSystem<DataSystem>().DataSave();
        shopUI.SetActive(false);
        shopBut.SetActive(true);
        startBut.SetActive(true);
    }
}