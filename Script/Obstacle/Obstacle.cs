using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public Player knight;
    public int dmg;
    
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="Player")
        {
            knight.EnemyDameged(dmg); 
        }
    }
}
