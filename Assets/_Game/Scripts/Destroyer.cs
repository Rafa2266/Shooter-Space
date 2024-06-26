using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D target)
    {
        if (target.CompareTag("PlayerProjectTile") || target.CompareTag("EnemyProjectTile"))
        {
            Destroy(target.gameObject);
        }
        
    }
}
