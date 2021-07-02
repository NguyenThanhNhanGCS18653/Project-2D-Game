using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SwordLightBullet
public class SwordLight : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public int dmg = 3;
    public float timeexist = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play("SwordLight");
        timeexist -= Time.deltaTime;
        if (timeexist <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
            TurretAI turret = col.GetComponent<TurretAI>();
            if (turret != null)
            {
                turret.Damage(dmg);
                Destroy(gameObject);
            }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakenDmg(dmg);
            Destroy(gameObject);
        }

        Enemy2 enemy2 = collision.GetComponent<Enemy2>();
        if (enemy2 != null)
        {
            enemy2.TakenDame(dmg);
            Destroy(gameObject);
        }

        Fly_Enemy flyEnemy = collision.GetComponent<Fly_Enemy>();
        if (flyEnemy != null)
        {
            flyEnemy.TakeDame(dmg);
            Destroy(gameObject);
        }

        Enemy3 enemy3 = collision.GetComponent<Enemy3>();
        if (enemy3 != null)
        {
            enemy3.TakenDmg(dmg);
            Destroy(gameObject);
        }

        Boss boss = collision.GetComponent<Boss>();
        if (boss != null)
        {
            boss.ApplyDmg(dmg);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Grass")
        {
            Destroy(gameObject);
        }
    }

}
