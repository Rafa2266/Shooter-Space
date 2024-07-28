using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControllerMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject panelSettings,panelOptions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExitGameBackAndroidButton();
    }
    public void ButtonOpenSettings()
    {
        panelSettings.SetActive(true);
        panelOptions.SetActive(false);
    }

    public void ButtonCloseSettings()
    {
        panelSettings.SetActive(false);
        panelOptions.SetActive(true);
        GameData gameData = FindObjectOfType<GameData>();
        SettingsController settingsController = FindObjectOfType<SettingsController>();
        gameData.SaveSounds(settingsController.soundOnOff);

    }

    public void ButtonStartGame(string sceneName)
    {
        SceneController sceneController = FindObjectOfType<SceneController>();
        sceneController.loadScene(sceneName);
    }

    public void ButtonSound()
    {
        SettingsController settingsController = FindObjectOfType<SettingsController>();
        settingsController.SoundOnOff();
    }

    private void ExitGameBackAndroidButton()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call<bool>("moveTaskToBack", true);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
