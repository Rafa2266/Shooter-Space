using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
   public void FadeIn()
    {
        string sceneName= UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        switch(sceneName)
        {
            case "Main Menu":
                {
                    UiControllerMainMenu uiControllerMainMenu= FindObjectOfType<UiControllerMainMenu>();
                    uiControllerMainMenu.imageFade.GetComponent<Animator>().SetTrigger("FadeOut");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
                    break;
                }
            case "Game":
                {
                    UIController uiController = FindObjectOfType<UIController>();
                    uiController.imageFade.GetComponent<Animator>().SetTrigger("FadeOut");
                    GameController gameController= FindObjectOfType<GameController>();
                    gameController.RestartGameplay();
                    break;
                }
        }
    }
    public void FadeOut()
    {
        this.gameObject.SetActive(false);
    }
}
