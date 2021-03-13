using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DouduckGame;

[CreateAssetMenu(fileName = "DataIn")]
public class DataIn : ScriptableObject
{
    public ItemBase[] dataIn;
}
[System.Serializable]
public class ItemBase
{
    public string itemName;
    public Sprite texture;
    public int unlockCost;
    public TextAsset description;
    //public bool unlocked = false;

    public Sprite Texture
    {
        get { return texture; }
        set { texture = value; }
    }
    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
    //public bool isUnlock
    //{
    //    get { return unlocked; }
    //    set { unlocked = value; }
    //}
    public bool Unlock()
    {
        if (DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().coin >= unlockCost)
        {
            //unlocked = true;
            DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().coin -= unlockCost;
            return true;
        }
        return false;
    }
}

public class Cloth : ItemBase
{

}

public class Character : ItemBase
{

}

