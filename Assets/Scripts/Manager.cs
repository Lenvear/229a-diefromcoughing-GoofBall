using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public static bool Game_Win = false;

    [SerializeField] private Text Coin_left;
    [SerializeField] private Text Timer;
    [SerializeField] private GameObject Win;
    public static int Coin_Exist = 2;
    float elapsedTime;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Coin_left.text = "Coin Uncollected " + Coin_Exist.ToString() + " Left";
    }

    // Update is called once per frame
    void Update()
    {
        if (Coin_Exist <= 0)
        {
            Coin_left.text = "You Win";
        } 
        if (Coin_Exist == 0 & Game_Win == false)
        {
            print("You Win");
            Win.SetActive(true);
            Game_Win = true;
        }

        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        Timer.text = String.Format("{00:00}:{1:00}", minutes,seconds);
    }
    public void Coin_Get()
    {
        Coin_Exist -= 1;
        Coin_left.text = "Coin Uncollected " + Coin_Exist.ToString() + " Left";
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
