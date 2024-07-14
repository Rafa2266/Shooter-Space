using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{

    private ItemController itemController;
    // Start is called before the first frame update
    void Start()
    {
        itemController=FindObjectOfType<ItemController>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (this.transform.gameObject.CompareTag("ItemShield"))
        {
            if(target.gameObject.CompareTag("Player") || target.gameObject.CompareTag("Shield"))
            {
                itemController.ItemShield(target);
                Destroy(this.gameObject);
            }
        }
        else if (this.transform.gameObject.CompareTag("ItemHealth"))
        {
            if (target.gameObject.CompareTag("Player") || target.gameObject.CompareTag("Shield"))
            {
                itemController.ItemFullHeath();
                Destroy(this.gameObject);
            }
        }
    }
           
}
