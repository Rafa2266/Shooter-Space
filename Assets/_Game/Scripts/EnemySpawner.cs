using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        SpawnUntilFull();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnUntilFull()
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
