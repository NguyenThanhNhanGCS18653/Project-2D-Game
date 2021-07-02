using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public int HP = 10;
    public float shootinginterval;
    public float playerrange;
    public float wakeuprange = 8f;
    public float bulletspeed = 5f;
    public float bullettime;

    public Transform player;
    public GameObject bullet;
    public Transform shootleft;
    public Transform shootright;

    public Sounds sound;

    Animation anim;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        sound = GameObject.FindWithTag("sound").GetComponent<Sounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x>transform.position.x)//check the position of the turret character who will look left and right
        {
            animator.SetBool("TurretLookRight", true);
        }
        if (player.transform.position.x<transform.position.x)
        {   
            animator.SetBool("TurretLookRight", false);
        }
        TurretRangeCheck();
        if (HP <= 0)
        {
            sound.PlaySound("destroy");
            Destroy(gameObject);
        }
    }
    public void TurretRangeCheck()//If the character's distance is equal to or less than the turret range, the turret will appear.
    {
        playerrange = Vector2.Distance(player.transform.position, transform.position);
        if (playerrange<wakeuprange)
        {
           animator.SetBool("WakeUp", true);
        }
        if (playerrange>=wakeuprange)
        {
            animator.SetBool("WakeUp", false);
        }
    }
    public void Attack(bool attackright)//turret attack player.
    {
        bullettime += Time.deltaTime;
        if (bullettime>= shootinginterval)
        {
            Vector2 vector2 = (player.transform.position - transform.position).normalized;
            //vector2.Normalize();
            
            if (attackright==true)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootright.transform.position, shootright.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = vector2 * bulletspeed;
                bullettime = 0;
            }
            if (attackright==false)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootleft.transform.position, shootleft.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = vector2 * bulletspeed;
                bullettime = 0;
            }
        }
    }
    public void Damage(int dmg)
    {
        HP -= dmg;
        anim.Play("redflash");
    }
}
