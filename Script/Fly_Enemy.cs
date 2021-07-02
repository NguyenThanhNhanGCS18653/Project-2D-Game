using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Enemy : MonoBehaviour
{
    public float speed;
    public float range;
    public float shootrange;
    public float fire_rate = 1f;
    private float nextfire_rate;
    public int HP = 15;

    private Animation animation;
    Animator animator;
    Rigidbody2D rb;
    GameObject targetKnight;
    public GameObject bulletPrefab;
    public GameObject shootpoint;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        targetKnight = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        animator.Play("FlyEne_Idle");
        if (distance < range && distance > shootrange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distance <= shootrange && nextfire_rate < Time.time)
        {
            GameObject bullet_flyEne = Instantiate(bulletPrefab, shootpoint.transform.position, shootpoint.transform.rotation);
            nextfire_rate = Time.time + fire_rate;
        }


        if (player.transform.position.x > transform.position.x)//Flip follow the knight
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
           
        }
        else
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
        FlyEnemyDie();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, shootrange);
    }

    public void TakeDame(int dmg)
    {
        HP -= dmg;
        animation.Play("redflash");
    }
    void FlyEnemyDie()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
