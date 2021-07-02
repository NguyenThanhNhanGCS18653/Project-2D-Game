using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Enemy3 : MonoBehaviour
{
    public int dame = 2;
    float timeExis = 2f;
    public float speed;


    GameObject targetKnight;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        targetKnight = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeExis -= Time.deltaTime;
        if (timeExis <= 0)
        {
            Destroy(gameObject);
        }
        Vector2 direction = (targetKnight.transform.position - transform.position).normalized * speed;//bulet follow the knight with speed
        rb.velocity = new Vector2(direction.x, direction.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player knight = collision.GetComponent<Player>();
        if (knight != null)
        {
            knight.EnemyDameged(dame);
            Destroy(gameObject);
        }
    }
}
