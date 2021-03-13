using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DouduckGame;

public class Shop : MonoBehaviour
{
    public GameObject container;
    public GameObject content;
    public GameObject confirm;
    public Text coinText;
    public static string state;
    private void Start()
    {
        ItemClear();
        state = "Skin";
        ClothsFillIn();
    }
    private void Update()
    {
        coinText.text = "X " + DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().coin.ToString();
    }
    public void SkinButton()
    {
        DouduckGameCore.GetSystem<DataSystem>().DataSave();
        ItemClear();
        state = "Skin";
        ClothsFillIn();
    } 
    public void CharacterButton()
    {
        DouduckGameCore.GetSystem<DataSystem>().DataSave();
        ItemClear();
        state = "Character";
        CharacterFillIn();
    }
    void ItemClear()
    {
        for(int i = 0; i < content.transform.childCount; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }
    }
    void ClothsFillIn()
    {
        for (int i = 0; i < DouduckGameCore.GetSystem<DataSystem>().skins.dataIn.Length; i++)
        {
            //container.GetComponent<Selected>().thisIndex = i;
            GameObject temp = Instantiate(container, content.transform);
            temp.GetComponent<Selected>().thisIndex = i;
        }
    }
    void CharacterFillIn()
    {
        for (int i = 0; i < DouduckGameCore.GetSystem<DataSystem>().squids.dataIn.Length; i++)
        {
            //container.GetComponent<Selected>().thisIndex = i;
            GameObject temp = Instantiate(container, content.transform);
            temp.GetComponent<Selected>().thisIndex = i;
        }
    }
}