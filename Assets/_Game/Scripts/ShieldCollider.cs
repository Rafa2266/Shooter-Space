using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {

        if (target.gameObject.CompareTag("EnemyProjectTile"))
        {
            Destroy(target.gameObject);
        }
        else if(target.gameObject.CompareTag("Enemy"))
        {
            //Destruição do inimigo e jogador
        }
        
    }
}
