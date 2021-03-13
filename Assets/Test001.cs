using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DouduckGame;

public class Test001 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            DouduckGameCore.AddSystem<GameManager>();
        if (Input.GetKeyDown(KeyCode.S))
            DouduckGameCore.RemoveSystem<InputSystem>();
        if(Input.GetKeyDown(KeyCode.D))
            DouduckGameCore.GetSystem<InputSystem>().InputBeginEvent.AddListener(Tessst);
    }
    void Tessst()
    {
        Debug.Log("QQQQQQQ");
    }
}
