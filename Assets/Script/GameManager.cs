using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static DataIn skins;
    public static DataIn squids;
    public static GameManager ins;
    public static PlayerData data;

    //public DataSystem dataSys;

    public GameObject[] characterPref;
    private void Awake()
    {
        skins = (DataIn)Resources.Load("Skins");
        squids = (DataIn)Resources.Load("Squids");
        DataLoad();
        //dataSys.DataLoad();
        if (data == null)
        {
            data = new PlayerData();
            //data.Inital();
            DataSave();
        }

        if (ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (ins != this)
        {
            Destroy(gameObject);
        }  
    }
    private void Start()
    {

    }
    private void Update()
    {
        #region Dev ONLY
        if (Input.GetKeyDown(KeyCode.G))
        {
            data.Inital();
            DataSave();

            Debug.Log("Inital");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            for(int i = 0; i < squids.dataIn.Length; i++)
            {
                GameManager.data.unlockedSkinsID[i] = false;
            }
            DataSave();
            Debug.Log("SkinClear");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            data.coin += 50;
            DataSave();
        }
        #endregion
    }
    public static void DataSave()
    {
        PlayerPrefs.SetString("jsonPlayerData", JsonUtility.ToJson(data));
        
        Debug.Log("Saved");
        //Debug.Log(data.coin);
    }
    public static void DataLoad()
    {
        data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("jsonPlayerData"));
        Debug.Log("Loaded");
        //Debug.Log(data.coin);
    }
}

public class PlayerData
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
            foreach (ItemBase i in GameManager.skins.dataIn)
            {
                unlockedSkinsID.Add(false);
            }
            foreach (ItemBase i in GameManager.squids.dataIn)
            {
                unlockedSquidsID.Add(false);
            }
        }
    }
    public PlayerData()
    {
        Inital();
    }
}

