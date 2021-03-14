using UnityEngine;
using System.Collections;
using DouduckGame;

public class GameManager : IGameSystemMono
{
    public override void StartGameSystem()
    {
        DouduckGameCore.GetSystem<DataSystem>().DataLoad();
    }
    public override void DestoryGameSystem() { }
    private void Update()
    {
        #region Dev ONLY
        if (Input.GetKeyDown(KeyCode.G))
        {
            DouduckGameCore.GetSystem<DataSystem>().PlayDataInital();
            DouduckGameCore.GetSystem<DataSystem>().DataSave();

            Debug.Log("Inital");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < DouduckGameCore.GetSystem<DataSystem>().skins.dataIn.Length; i++)
            {
                DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().unlockedSkinsID[i] = false;
            }
            DouduckGameCore.GetSystem<DataSystem>().DataSave();
            Debug.Log("SkinClear");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DouduckGameCore.GetSystem<DataSystem>().GetPlayerData().coin += 50;
            DouduckGameCore.GetSystem<DataSystem>().DataSave();
        }
        #endregion
    }
}
