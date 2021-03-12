using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject container;
    public GameObject content;
    public GameObject confirm;
    public Text coinText;
    public static string state;
    private void Start()
    {
        //GameManager.DataLoad();
        ItemClear();
        state = "Skin";
        ClothsFillIn();
    }
    private void Update()
    {
        coinText.text = "X " + GameManager.data.coin.ToString();
    }
    public void SkinButton()
    {
        GameManager.DataSave();
        ItemClear();
        state = "Skin";
        ClothsFillIn();
    } 
    public void CharacterButton()
    {
        GameManager.DataSave();
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
        for (int i = 0; i < GameManager.skins.dataIn.Length; i++)
        {
            //container.GetComponent<Selected>().thisIndex = i;
            GameObject temp = Instantiate(container, content.transform);
            temp.GetComponent<Selected>().thisIndex = i;
        }
    }
    void CharacterFillIn()
    {
        for (int i = 0; i < GameManager.squids.dataIn.Length; i++)
        {
            //container.GetComponent<Selected>().thisIndex = i;
            GameObject temp = Instantiate(container, content.transform);
            temp.GetComponent<Selected>().thisIndex = i;
        }
    }
}