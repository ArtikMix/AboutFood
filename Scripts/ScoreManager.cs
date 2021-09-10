using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;//надо продумать систему счёта

    private void Start()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
        }
        else
        {
            PlayerPrefs.SetInt("score", 0);
        }
    }
    public void TopUp(int s)
    {
        score += s;
        PlayerPrefs.SetInt("score", score);
    }
}
