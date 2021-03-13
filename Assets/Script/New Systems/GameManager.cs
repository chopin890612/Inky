using UnityEngine;
using System.Collections;
using DouduckGame;

public class GameManager : IGameSystemMono
{
    public override void StartGameSystem()
    {
        DouduckGameCore.AddSystem<DataSystem>();
    }
    public override void DestoryGameSystem() { }

    private void Start()
    {
        DouduckGameCore.GetSystem<DataSystem>().DataLoad();
    }
}
