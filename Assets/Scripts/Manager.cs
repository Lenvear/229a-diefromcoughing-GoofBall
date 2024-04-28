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
    public static int Coin_Exist = 10;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Coin_left.text = "Coin uncollected " + Coin_Exist.ToString() + " Left";
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
    }
    public void Pin_Down()
    {
        Coin_Exist -= 1;
        Coin_left.text = "Pin Need to Hit " + Coin_Exist.ToString() + " Left";
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
