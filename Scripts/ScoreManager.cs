using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;//надо продумать систему счёта
    [SerializeField] private Text txt;

    private void Start()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
        }
        else
        {
            PlayerPrefs.SetInt("score", 0);
            score = 0;
        }
        txt.text = score.ToString();
    }
    public void TopUp(int s)
    {
        score += s;
        txt.text = score.ToString();
        PlayerPrefs.SetInt("score", score);
    }
}
