using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpIteam : MonoBehaviour
{
    private InventoryPlayer inventory;
    public GameObject itemButton;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<InventoryPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            for (int i = 0; i< inventory.slot.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //Add item in inventory ^^
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slot[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
                
            }
        }
        
    }
}
