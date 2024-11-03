using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float rotatePartsSpeed, playerShieldDuration,itemSpeed;
    [HideInInspector] public int enemyCount;
    public int maxEnemies;

    private UIController uiController;
    private Player player;
    [SerializeField] private GameObject[] items;

    private Color32 greenColorHealth=new Color32(0,128,0,255);
    private Color32 orangeColorHealth=new Color32(255,165,0,255);
    private Color32 redColorHealth=new Color32(255,0,0,255);

    [HideInInspector] public int currentScore;
    [HideInInspector] public bool gameover;

    public Transform allProjectiles, allParts;

    [SerializeField] private Transform playerStartPosition;


    // Start is called before the first frame update
    void Start()
    {
        currentScore= 0;
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

    public void PlayerFullHealth()
    {
        UnityEngine.UI.Image fill = uiController.sliderPlayerHealth.transform.Find("Fill Area").GetComponentInChildren<UnityEngine.UI.Image>();
        player.health = player.maxHealth;
        uiController.sliderPlayerHealth.value= player.health;
        fill.color = greenColorHealth;
    }

    public void CreateItem(Transform enemy)
    {
        int randomNumber = Random.Range(1, 101);

        if (randomNumber >= 75)
        {
            GameObject tempItem = Instantiate(items[Random.Range(0, items.Length)], enemy.transform.position, Quaternion.identity);
        }
    }

    public void GameOver()
    {
        gameover= true;
        player.gameObject.SetActive(false);
        player.health = 0;
        StartCoroutine(RestartDelay());

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {GameObject.Destroy(enemy);

        }
            
        GameData gameData= FindObjectOfType<GameData>();

        if(gameData.highscore<currentScore)
        {
            gameData.SaveScore(currentScore);
        }
        
    }

    public void RestartGame()
    {
        uiController.imageFade.gameObject.SetActive(true);
        uiController.imageFade.gameObject.GetComponent<Animator>().SetTrigger("FadeIn");
    }

    public void RestartGameplay()
    {  
        EnemySpawner enemySpawner= FindObjectOfType<EnemySpawner>();
        player.transform.position = playerStartPosition.position;
        gameover = false;
        player.gameObject.SetActive(true);
        player.health = player.maxHealth;
       
        uiController.sliderPlayerHealth.value= player.health;
        currentScore= 0;
        uiController.txtScore.text= "Score :" + currentScore.ToString();
        enemyCount = maxEnemies;
        enemySpawner.SpawnUntilFull();
        UnityEngine.UI.Image fill = uiController.sliderPlayerHealth.transform.Find("Fill Area").GetComponentInChildren<UnityEngine.UI.Image>();
        fill.color = greenColorHealth;
        foreach(Transform child in allParts.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in allProjectiles.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public IEnumerator RestartDelay()
    {
        yield return new WaitForSeconds(1f);
        RestartGame();
    }
}
