using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn()
    {
        Vector2 playerpos = new Vector2(player.position.x + 2f, player.position.y);
        Instantiate(item, playerpos, Quaternion.identity);
    }
}
