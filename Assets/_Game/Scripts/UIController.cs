using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UIController : MonoBehaviour
{
    public Slider sliderPlayerHealth;
    private GameController gameController;
    public TMP_Text txtScore;
    public Image imageFade;
    public Toggle[] shootStyle;

    [SerializeField] private GameObject panelPause, panelGame;
    // Start is called before the first frame update
    void Start()
    {
       Initialize();
    }

    private void Initialize()
    {
        gameController = FindObjectOfType<GameController>();
        txtScore.text = "Score :" + gameController.currentScore.ToString();
        GameData gameData = FindObjectOfType<GameData>();
        bool value = gameData.GetShootStyle();

        if (!value)
        {
            shootStyle[0].isOn= true;
            shootStyle[1].isOn= false;
            shootStyle[0].interactable = false;
            shootStyle[1].interactable = true;
        }
        else
        {
            shootStyle[0].isOn = false;
            shootStyle[1].isOn = true;
            shootStyle[0].interactable = true;
            shootStyle[1].interactable = false;
        }
    }

    public void UpdateScore()
    {
        txtScore.text = "Score :" + gameController.currentScore.ToString();
    }

    public void ToggleShootStyle()
    {
        GameData gameData = FindObjectOfType<GameData>();
        if (shootStyle[0].isOn)
        {
            gameData.shootStyle = false;
            shootStyle[0].interactable= false;
            shootStyle[1].interactable= true;
        }
        else if (shootStyle[1].isOn) 
        {
            gameData.shootStyle = true;
            shootStyle[0].interactable = true;
            shootStyle[1].interactable = false;
        }
    }

    public void ButtonOpenPanelPause()
    {
        panelPause.SetActive(true);
        panelGame.SetActive(false);
        Time.timeScale = 0f;
    }
    public void ButtonClosePanelPause()
    {
        panelPause.SetActive(false);
        panelGame.SetActive(true);
        GameData gameData = FindObjectOfType<GameData>();
        SettingsController settingsController=FindObjectOfType<SettingsController>();
        gameData.SaveSounds(gameData.soundOnOff);
        gameData.saveShootStyle(gameData.shootStyle);
        Time.timeScale = 1f;
        
    }

    public void ButtonBackMainMenu(string sceneName)
    {
        Time.timeScale = 1f;
        SceneController sceneController= FindObjectOfType<SceneController>();
        sceneController.loadScene(sceneName);
    }

    public void ButtonSound()
    {
        SettingsController settingsController= FindObjectOfType<SettingsController>();
        settingsController.SoundOnOff();
    }
}
