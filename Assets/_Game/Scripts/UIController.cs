using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UIController : MonoBehaviour
{
    public Slider sliderPlayerHealth;
    private GameController gameController;
    [SerializeField] private TMP_Text txtScore;

    [SerializeField] private GameObject panelPause, panelGame;
    // Start is called before the first frame update
    void Start()
    {
        gameController=FindObjectOfType<GameController>();
        txtScore.text = "Score :" + gameController.currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore()
    {
        txtScore.text = "Score :" + gameController.currentScore.ToString();
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
