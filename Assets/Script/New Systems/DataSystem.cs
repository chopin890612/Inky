using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DouduckGame;

public class DataSystem : IGameSystemMono
{
    private PlayerData playerData;
    public DataIn skins;
    public DataIn squids;
    public DataIn libs;


    public override void StartGameSystem()
    {
        skins = (DataIn)Resources.Load("Skins");
        squids = (DataIn)Resources.Load("Squids");
    }
    public override void DestoryGameSystem() { }


    public void DataSave()
    {
        PlayerPrefs.SetString("jsonPlayerData", JsonUtility.ToJson(playerData));
    }
    public void DataLoad()
    {
        playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("jsonPlayerData"));

        if(playerData == null)
        {
            PlayDataInital();
        }
    }
    public void PlayDataInital()
    {
        playerData = new PlayerData();
        foreach (ItemBase i in skins.dataIn)
        {
            playerData.unlockedSkinsID.Add(false);
        }
        foreach (ItemBase i in squids.dataIn)
        {
            playerData.unlockedSquidsID.Add(false);
        }
        DataSave();
    }
    public PlayerData GetPlayerData() { return playerData; }


}

public class PlayerData
{
    public int[] selectID = new int[2] { 0, 0 };
    public List<bool> unlockedSkinsID = new List<bool>();
    public List<bool> unlockedSquidsID = new List<bool>();
    public List<bool> unlockedLibID = new List<bool>();
    public int coin;
    public int highestScore;
    public Vector2 speedScale = Vector2.one;
    private void Inital()
    {
        {
            coin = 0;
            highestScore = 0;
            speedScale = Vector2.one;
            selectID = new int[2] { 0, 0 };

            unlockedSkinsID.Clear();
            unlockedSquidsID.Clear();
            //foreach (ItemBase i in DouduckGameCore.GetSystem<DataSystem>().skins.dataIn)
            //{
            //    unlockedSkinsID.Add(false);
            //}
            //foreach (ItemBase i in DouduckGameCore.GetSystem<DataSystem>().squids.dataIn)
            //{
            //    unlockedSquidsID.Add(false);
            //}
        }
    }
    public PlayerData()
    {
        Inital();
    }
}