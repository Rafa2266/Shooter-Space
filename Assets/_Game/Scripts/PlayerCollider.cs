using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("EnemyProjectTile"))
        {
            this.gameObject.GetComponent<Player>().health -= target.GetComponent<ProjectTile>().damage;
            Destroy(target.gameObject);
            if(this.gameObject.GetComponent<Player>().health <= 0)
            {
                this.gameObject.GetComponent<Player>().Playerdeath();
            }
        }
    }
}
