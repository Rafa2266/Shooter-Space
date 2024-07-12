using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject laserPrefab;

    [SerializeField] private Transform spawnPointPosition;

    [SerializeField] private float firingRate;

    private float timeToShot;

    private GameController gameController;

    public int health,maxHealth;
    // Start is called before the first frame update
    void Awake()
    {
        gameController=FindObjectOfType<GameController>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        ShootProjectTile();
    }
    private void ShootProjectTile()
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

    public void Playerdeath()
    {
        Explosion explosion = gameController.gameObject.GetComponent<Explosion>();
        explosion.Explode(this.transform);
        this.gameObject.SetActive(false);
    }
}
