using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [HideInInspector] public int highscore;
    public bool soundOnOff, shootStyle;
    private int firstGameplay = 0;

    private void Awake()
    {
        firstGameplay = PlayerPrefs.GetInt("firstGameplay");
    }
    // Start is called before the first frame update
    void Start()
    {
        if(firstGameplay == 0)
        {
            soundOnOff= true;
            shootStyle= true;
            SaveSounds(soundOnOff);
            saveShootStyle(shootStyle);
            PlayerPrefs.SetInt("firstGameplay", 1);
        }
        else
        {
            soundOnOff= GetSounds();
            shootStyle=GetShootStyle();
            highscore=GetScore();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveScore(int highscore)
    {
        PlayerPrefs.SetInt("highscore", highscore);
    }

    public int GetScore()
    {
        int highscore = PlayerPrefs.GetInt("highscore");
        return highscore;
    }

    public void SaveSounds(bool soundOnOff)
    {
        if(soundOnOff)
        {
            PlayerPrefs.SetInt("sounds", 1);
        }
        else
        {
            PlayerPrefs.SetInt("sounds", 0);

        }
    }

    public bool GetSounds()
    {
        if (PlayerPrefs.GetInt("sounds") == 0)
        {
            soundOnOff = false;
        }
        if (PlayerPrefs.GetInt("sounds") == 1)
        {
            soundOnOff = true;
        }
        return soundOnOff;
    }

    public void saveShootStyle(bool shootStyle)
    {
        if (shootStyle)
        {
            PlayerPrefs.SetInt("shootStyle", 1);
        }
        else
        {
            PlayerPrefs.SetInt("shootStyle", 0);

        }
    }
    public bool GetShootStyle()
    {
        if (PlayerPrefs.GetInt("shootStyle") == 0)
        {
            shootStyle = false;
        }
        if (PlayerPrefs.GetInt("shootStyle") == 1)
        {
            shootStyle = true;
        }
        return shootStyle;
    }
}
