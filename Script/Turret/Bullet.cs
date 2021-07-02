using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dmg = 2;
    public float timetoexist = 2f;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timetoexist -= Time.deltaTime;
        if (timetoexist <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true)
        {
            if (col.gameObject.tag == "Player")
            {
                player.EnemyDameged(dmg);

            }
            Destroy(gameObject);
        }

    }
}
