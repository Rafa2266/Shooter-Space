using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool shootAutomatic, shootManual;
    public float rotatePartsSpeed, playerShieldDuration;
    [HideInInspector] public int enemyCount;
    public int maxEnemies;

    private UIController uiController;
    private Player player;

    private Color32 greenColorHealth=new Color32(0,128,0,255);
    private Color32 orangeColorHealth=new Color32(255,165,0,255);
    private Color32 redColorHealth=new Color32(255,0,0,255);
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = maxEnemies;
        uiController=FindObjectOfType<UIController>();
        player=FindObjectOfType<Player>();
        uiController.sliderPlayerHealth.maxValue=player.maxHealth;
        uiController.sliderPlayerHealth.value=player.health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeColorSliderHealth()
    {
        UnityEngine.UI.Image fill = uiController.sliderPlayerHealth.transform.Find("Fill Area").GetComponentInChildren<UnityEngine.UI.Image>();
        if ( player.health > player.maxHealth * 0.7)
        {
            fill.color = greenColorHealth;
        }
        else if (player.health > player.maxHealth*0.25 && player.health <= player.maxHealth * 0.7)
        {
           fill.color = orangeColorHealth;
        }
        else
        {
           fill.color = redColorHealth;
        }
    }
}
