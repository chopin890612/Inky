using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DouduckGame;

public class ScenesManager : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("gamemode"); 
    }
    public void StartGame() 
    {
        SceneManager.LoadScene("gamemode"); 
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("main");
        DouduckGameCore.GetSystem<DataSystem>().DataSave();
        Time.timeScale = 1f;
    }
    void LoadSScene()
    {
       SceneManager.LoadScene("gamemode"); 
    }
    void MMainMenu()
    {
        SceneManager.LoadScene("main");
        DouduckGameCore.GetSystem<DataSystem>().DataSave();
        Time.timeScale = 1f;
    }
}
