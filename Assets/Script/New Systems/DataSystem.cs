using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DouduckGame;

public class DataSystem : IGameSystemMono
{
    private PlayerDataNew PlayerData;
    public DataIn skins;
    public DataIn squids;


    public override void StartGameSystem()
    {
        skins = (DataIn)Resources.Load("Skins");
        squids = (DataIn)Resources.Load("Squids");
    }
    public override void DestoryGameSystem() { }


    public void DataSave()
    {
        PlayerPrefs.SetString("jsonPlayerData", JsonUtility.ToJson(PlayerData));
    }
    public void DataLoad()
    {
        PlayerData = JsonUtility.FromJson<PlayerDataNew>(PlayerPrefs.GetString("jsonPlayerData"));

        if(PlayerData == null)
        {
            PlayerData = new PlayerDataNew();
            DataSave();
        }
    }
    public PlayerDataNew GetPlayerData() { return PlayerData; }


}

public class PlayerDataNew
{
    public int[] selectID = new int[2] { 0, 0 };
    public List<bool> unlockedSkinsID = new List<bool>();
    public List<bool> unlockedSquidsID = new List<bool>();
    public int coin;
    public int highestScore;
    public Vector2 speedScale = Vector2.one;
    public void Inital()
    {
        {
            coin = 0;
            highestScore = 0;
            speedScale = Vector2.one;
            selectID = new int[2] { 0, 0 };

            //unlockedSkinsID.Clear();
            //unlockedSquidsID.Clear();
            foreach (ItemBase i in DouduckGameCore.GetSystem<DataSystem>().skins.dataIn)
            {
                unlockedSkinsID.Add(false);
            }
            foreach (ItemBase i in DouduckGameCore.GetSystem<DataSystem>().squids.dataIn)
            {
                unlockedSquidsID.Add(false);
            }
        }
    }
    public PlayerDataNew()
    {
        Inital();
    }
}