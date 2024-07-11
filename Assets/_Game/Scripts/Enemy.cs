using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private FlashEffect flashEffect;
    private Explosion explosion;

    [SerializeField] private GameObject projectTile;
    [SerializeField] private Transform spawnProjectTilePosition;
    [SerializeField] private float startInvokeShoot,minShootValue,maxShootValue;
    private GameController gameController;
    private EnemySpawner enemySpawner;


    // Start is called before the first frame update
    void Start()
    {
        flashEffect=this.GetComponent<FlashEffect>();
        explosion=FindObjectOfType<Explosion>();
        enemySpawner=FindObjectOfType<EnemySpawner>();
        gameController=FindObjectOfType<GameController>();
        InvokeProjectTile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvokeProjectTile()
    {
        InvokeRepeating("ShootProjectTile",startInvokeShoot, Random.Range(minShootValue,maxShootValue));
    }

    private void ShootProjectTile()
    {
        GameObject tempProjectTile = Instantiate(projectTile,spawnProjectTilePosition.position,Quaternion.identity) as GameObject;
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("PlayerProjectTile"))
        {
            health -= target.GetComponent<ProjectTile>().damage;
            flashEffect.Flash();
        }
        if (health <= 0)
        {
            explosion.Explode(this.transform);
            Destroy(this.gameObject);
            gameController.enemyCount--;
            if(gameController.enemyCount == 0)
            {
                gameController.enemyCount = gameController.maxEnemies;
                enemySpawner.SpawnUntilFull();
            }
        }
        Destroy(target.gameObject);
    }
}
