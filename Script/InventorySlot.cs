using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private InventoryPlayer inventory;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<InventoryPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }
    public void ThrowItem()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<SpawnItem>().Spawn();
            GameObject.Destroy(child.gameObject);
        }
    }
}
