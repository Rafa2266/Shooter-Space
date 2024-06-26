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
    // Start is called before the first frame update
    void Start()
    {
        gameController=FindObjectOfType<GameController>();
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
}
