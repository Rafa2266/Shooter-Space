using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject laserPrefab;

    [SerializeField] private Transform spawnPointPosition;

    [SerializeField] private float firingRate;

    private GameObject shield;

    private float timeToShot, playerShieldDuration;

    private GameController gameController;

    [SerializeField] AudioClip deathAudio;


    public int health,maxHealth;
    // Start is called before the first frame update
    void Awake()
    {
        gameController=FindObjectOfType<GameController>();
        health = maxHealth;
        shield = this.transform.Find("Shield").gameObject;
        playerShieldDuration = gameController.playerShieldDuration;
    }

    // Update is called once per frame
    void Update()
    {
        ShootProjectTile();
    }

    public void InvokePlayerShield()
    {
        InvokeRepeating("PlayerShield", 0f, 1f);
    }
    private void PlayerShield()
    {
        playerShieldDuration--;
        if(playerShieldDuration>0)
        {
            shield.SetActive(true);
            this.transform.GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {
            shield.SetActive(false);
            this.transform.GetComponent<CircleCollider2D>().enabled = true;
            CancelInvoke("PlayerShield");
        }
    }
    private void ShootProjectTile()
    {
        if (health > 0)
        {
            timeToShot += Time.deltaTime;
            if(gameController.shootManual && Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began && timeToShot>=firingRate)
            {
                GameObject tempProjectTile= Instantiate(laserPrefab,spawnPointPosition.position,Quaternion.identity);
                timeToShot = 0f;
                return;
            }
            else if (gameController.shootAutomatic && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary && timeToShot >= firingRate)
            {
                GameObject tempProjectTile = Instantiate(laserPrefab, spawnPointPosition.position, Quaternion.identity);
                timeToShot = 0f;
                return;
            }
        }
        
    }

    public void Playerdeath()
    {
        Explosion explosion = gameController.gameObject.GetComponent<Explosion>();
        explosion.Explode(this.transform,deathAudio);
        this.gameObject.SetActive(false);
    }

}
