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
        SceneManager.LoadScene(1); 
    }
    public void StartGame() 
    {
        SceneManager.LoadScene(1); 
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetString("jsonData", JsonUtility.ToJson(DouduckGameCore.GetSystem<DataSystem>().GetPlayerData()));
        Time.timeScale = 1f;
    }
    void LoadSScene()
    {
       SceneManager.LoadScene(1); 
    }
    void MMainMenu()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetString("jsonData", JsonUtility.ToJson(DouduckGameCore.GetSystem<DataSystem>().GetPlayerData()));
        Time.timeScale = 1f;
    }
}
