using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public Transform spawner;
    public GameObject skin;
    public GameObject hookPref;
    public GameObject coinPref;
    public GameObject wall;
    public GameObject gameoverUI;
    public GameObject pauseUI;
    public GameObject optionsUI;
    public Text scoresText;
    public Text coinsText;
    public GameObject[] player;
    public static bool gaming;
    public static bool gameOver;
    int gameTime = 0;
    float spawnRate;
    float time;
    bool pauseTaped = false;
    void Start()
    {
        ScreenSetup();
        InvokeRepeating("Timer", 0, 1f);
        GameSetup();
        Instantiate(player[GameManager.data.selectID[1]]);
        skin = GameObject.Find("Cloth");
        skin.GetComponent<SpriteRenderer>().sprite = GameManager.skins.dataIn[GameManager.data.selectID[0]].Texture;

        gameoverUI.SetActive(false);
        pauseUI.SetActive(false);
        optionsUI.SetActive(false);

        //InvokeRepeating("Hook", 0, 0.5f);
    }
    private void Update()
    {
        if(Time.time > time + spawnRate && gaming)
        {
            HookSpawner();
            time = Time.time;
        }
        coinsText.text = "X " + GameManager.data.coin.ToString();

        if(!gaming)
        {
            CancelInvoke("Timer");
            if (gameOver)
            {
                gameoverUI.SetActive(true);
                if (gameTime > GameManager.data.highestScore)
                    GameManager.data.highestScore = gameTime-1;
                gameoverUI.transform.GetChild(0).gameObject.GetComponent<Text>().text = "HighScore:" + GameManager.data.highestScore.ToString();

                GameManager.DataSave();
                //Debug.Log("GAMEOVER!!!");
                gameOver = false;
            }
        }
    }
    void GameSetup()
    {
        gaming = true;
        gameOver = false;
    }
    void ScreenSetup()
    {
        float x = Camera.main.pixelHeight;
        float y = Camera.main.pixelWidth;
        float z = 2560f / 1440f;
        wall.transform.localScale = new Vector3(z / (x / y), wall.transform.localScale.y, wall.transform.localScale.z);
    }

    void HookSpawner()
    {
        spawner.position = new Vector2(Random.Range(-5f, 5f), spawner.position.y);
        Instantiate(hookPref, spawner.position, Quaternion.identity);
    }
    void Timer()
    {
        int min = 0;
        scoresText.text = "分數:"+gameTime.ToString();
        gameTime += 1;
        if (gameTime < 60)
        {
            spawnRate = 1f;
            min = 0;
        }
        else if (gameTime < 120)
        {
            spawnRate = 0.5f;
            min = 10;
        }
        else if (gameTime < 200)
        {
            spawnRate = 0.2f;
            min = 30;
        }
        else if (gameTime < 300)
        {
            spawnRate = 0.1f;
            min = 50;
        }
        CoinSpawner(min);
    }
    void CoinSpawner(int min)
    {
        int value;
        value = Random.Range(min, 100);
        if (value > 80)
            Instantiate(coinPref, new Vector2(Random.Range(-4f, 4f), Random.Range(-7f, 7f)), Quaternion.identity);
    }

    public void PauseUI()
    {
        if (!pauseTaped)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseUI.SetActive(false);
            optionsUI.SetActive(false);
            Time.timeScale = 1f;
        }
        pauseTaped = !pauseTaped;
    }
    public void OptionsUI()
    {
        optionsUI.transform.GetChild(0).gameObject.GetComponent<Slider>().value = GameManager.data.speedScale.x;
        optionsUI.transform.GetChild(1).gameObject.GetComponent<Slider>().value = GameManager.data.speedScale.y;
        optionsUI.SetActive(true);
    }
    public void ApplyBuuton()
    {
        GameManager.data.speedScale = new Vector2(optionsUI.transform.GetChild(0).gameObject.GetComponent<Slider>().value, optionsUI.transform.GetChild(1).gameObject.GetComponent<Slider>().value);
        optionsUI.SetActive(false);
    }
    public void BackButton()
    {
        optionsUI.SetActive(false);
    }
}