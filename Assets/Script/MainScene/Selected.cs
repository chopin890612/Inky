﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DouduckGame;


public class Selected : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    GameObject confirmUI;
    public GameObject descriptionUI;
    GameObject yesBut;
    GameObject noBut;
    ItemBase item;
    public GameObject blocker;
    GameObject selectMask;
    GameObject UIBackground;
    GameObject tempDescriptionUI;
    public int thisIndex;
    bool select = false;
    float pressTime;
    bool buttonStart;
    bool trigger;
    private void Start()
    {
        if (Shop.state == "Skin")
            item = DouduckGameCore.GetSystem<DataSystem>().skins.dataIn[thisIndex];
        else
            item = DouduckGameCore.GetSystem<DataSystem>().squids.dataIn[thisIndex];
        gameObject.GetComponent<Image>().sprite = item.Texture;
        gameObject.name = item.ItemName;
        blocker = gameObject.transform.GetChild(0).gameObject;

        if ((gameObject.name == DouduckGameCore.GetSystem<DataSystem>().squids.dataIn[0].ItemName) || (gameObject.name == DouduckGameCore.GetSystem<DataSystem>().skins.dataIn[0].ItemName))
            blocker.SetActive(false);

        if(Shop.state == "Skin" && DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().unlockedSkinsID[thisIndex])
            blocker.SetActive(false);
        if(Shop.state == "Character" && DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().unlockedSquidsID[thisIndex])
            blocker.SetActive(false);
            
            
        selectMask = transform.GetChild(1).gameObject;

        confirmUI = GameObject.Find("ConfirmUI");
        UIBackground = GameObject.Find("UIBackGround");

        yesBut = confirmUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        noBut = confirmUI.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        blocker.GetComponent<Button>().onClick.AddListener(confirmUI.GetComponent<Confirm>().unlockConfirm);
        blocker.GetComponent<Button>().onClick.AddListener(Select);
        yesBut.GetComponent<Button>().onClick.AddListener(Unlock);
        noBut.GetComponent<Button>().onClick.AddListener(UnSelect);
        blocker.transform.GetChild(1).GetComponent<Text>().text = "X " + item.unlockCost.ToString();
    }
    public void Seleced()
    {
        if (Shop.state == "Skin")
        {
            DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().selectID = new int[] { thisIndex, DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().selectID[1] };
            //Debug.Log(GameManager.data.SelectedID[0] + ", " + GameManager.data.SelectedID[1]);
        }
        else
        {
            DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().selectID = new int[] { DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().selectID[0], thisIndex };
            //Debug.Log(GameManager.data.SelectedID[0] + ", " + GameManager.data.SelectedID[1]);
            
        }
    }
    private void Update()
    {

        if(Shop.state == "Skin")
        {
            if (DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().selectID[0] == thisIndex)
                selectMask.SetActive(true);
            else
                selectMask.SetActive(false);
        }
        else if(Shop.state == "Character")
        {
            if (DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().selectID[1] == thisIndex)
                selectMask.SetActive(true);
            else
                selectMask.SetActive(false);
        }

        if(buttonStart && Time.time - pressTime > 0.5f && !trigger)
        {

            tempDescriptionUI = Instantiate(descriptionUI,Vector2.zero,Quaternion.identity,UIBackground.transform);
            if(Shop.state == "Skin")
            {
                tempDescriptionUI.transform.GetChild(1).GetComponent<Text>().text = DouduckGameCore.GetSystem<DataSystem>().skins.dataIn[thisIndex].description.text;
                tempDescriptionUI.transform.GetChild(2).GetComponent<Text>().text = item.ItemName;
            }
            else if(Shop.state == "Character")
            {
                tempDescriptionUI.transform.GetChild(1).GetComponent<Text>().text = DouduckGameCore.GetSystem<DataSystem>().squids.dataIn[thisIndex].description.text;
                tempDescriptionUI.transform.GetChild(2).GetComponent<Text>().text = item.ItemName;
            }
            tempDescriptionUI.transform.localPosition = Vector2.zero;
            trigger = true;

        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        LongPress(true);
        trigger = false;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        LongPress(false);
        trigger = true;
        //Destroy(tempDescriptionUI);
    }
    public void LongPress(bool bStart)
    {
        buttonStart = bStart;
        pressTime = Time.time;
    }
    public void Select()
    {
        select = true;
    }
    public void UnSelect()
    {
        select = false;
    }
    public void Unlock()
    {
        if(select && item.Unlock())
        {
            blocker.SetActive(false);
            if(Shop.state == "Skin")
                DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().unlockedSkinsID[thisIndex] = true;
            else if(Shop.state == "Character")
                DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().unlockedSquidsID[thisIndex] = true;
            select = false;
        }
    }
}

