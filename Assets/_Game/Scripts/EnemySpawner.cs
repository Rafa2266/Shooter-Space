using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay, formationDistanceScreenX, movementSpeed;
    private float minX, maxX;
    private bool isMoveRight;
    // Start is called before the first frame update
    void Start()
    {
        SpawnUntilFull();
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemies();
    }

    private void MoveEnemies()
    {
        if (isMoveRight)
        {
            transform.Translate(new Vector2(movementSpeed * Time.deltaTime,0f));
        }
        else
        {
            transform.Translate(new Vector2(-movementSpeed * Time.deltaTime, 0f));
        }

        ChangeDirection();
    }

    private void ChangeDirection()
    {
        if((transform.position.x - formationDistanceScreenX) < minX)
        {
            isMoveRight= true;
        }

        else if ((transform.position.x + formationDistanceScreenX) > maxX)
        {
            isMoveRight = false;
        }
    }

    private void SetMinAndMaxWidth()
    {
        Vector2 screenDimensions = Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.width,Screen.safeArea.height));
        minX= -screenDimensions.x;
        maxX= screenDimensions.x;
    }
    private void Initialize()
    {
        SetRandomDirectionMovement();
        SetMinAndMaxWidth();

    }

    private void SetRandomDirectionMovement()
    {
        int randomNumber= Random.Range(0, 2);
        
        if(randomNumber == 0 )
        {
            isMoveRight = false;
        }
        else
        {
            isMoveRight = true;
        }
    }

    public void SpawnUntilFull()
    {
        Transform availablePosition=NextFreePosition();
        if (availablePosition)
        {
            GameObject tempEnemY=Instantiate(enemyPrefab,availablePosition.position,Quaternion.identity) as GameObject;
            tempEnemY.transform.parent = availablePosition;
            Invoke("SpawnUntilFull",spawnDelay);
        }
    }

    private Transform NextFreePosition()
    {
        foreach (Transform child in this.transform) 
        {

            if (child.childCount == 0)
            {
                return child;
            }
        
        }
        return null;
    }
}
