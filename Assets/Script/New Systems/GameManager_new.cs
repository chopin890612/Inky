using UnityEngine;
using System.Collections;
using DouduckGame;

public class GameManagerNew : IGameSystemMono
{
    public override void StartGameSystem()
    {
        DouduckGameCore.AddSystem<DataSystem>();
    }
    public override void DestoryGameSystem() { }
}
