using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //생존 시간 갱신
    private float surviveTime;
    public Text surviveTimeText;
    private bool isGameOver;

    //게임오버
    public GameObject gameOverText;

    //최고기록
    public Text recordText;

    void Start()
    {
        surviveTime = 0f;
        isGameOver = false;
    }

    void Update()
    {
        if(!isGameOver)
        {
            surviveTime += Time.deltaTime;
            surviveTimeText.text = "Time : " + (int)surviveTime;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
            
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time : " + (int)bestTime;
    }
}
