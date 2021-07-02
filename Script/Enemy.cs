using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform raycast;
    public LayerMask raycastMask;
    public float raycastLength;
    public float attackDistance;
    public float moveSpeed;
    public float time;
    public Transform leftarea;
    public Transform rightarea;

    public Transform AttackPoint;
    
    Collider2D[] damePlayer;
    public int HP = 10;

    private Animation animation;
    private RaycastHit2D hit;
    private Transform target;
    private Animator animator;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float inTime;

    private void Awake()
    {
        ChooseTarget();
        inTime = time; //store the intial value of tim
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animation = GetComponent<Animation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attackMode == false)
        {
            Move();
        }
        if (Arealimit() == false && inRange == false && animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack") == false)
        {
            ChooseTarget();
        }
        if (inRange == true)
        {
            hit = Physics2D.Raycast(raycast.position, transform.right, raycastLength, raycastMask);
            RaycastDebugger();
        }
        //when Player is detected
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            Stopattack();
        }
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }


    void EnemyLogic()
    {
        distance = Vector2.Distance(target.position, transform.position);
        if (distance > attackDistance)
        {
            Stopattack();
        }
        else if (distance <= attackDistance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            animator.SetBool("Attack", false);
        }
    }

    void Move()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        time = inTime;
        attackMode = true;
        animator.SetBool("Attack", true);
        damePlayer = Physics2D.OverlapCircleAll(AttackPoint.position, 1f, raycastMask);
        foreach (Collider2D knight in damePlayer)
        {
            knight.GetComponent<Player>().EnemyDameged(2);
        }
    }
    void Cooldown()
    {
        time -= Time.deltaTime;
        if (time <= 0 && attackMode)
        {
            cooling = false;
            time = inTime;
        }
    }
    void Stopattack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("Attack", false);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            target = col.transform;
            inRange = true;
            Flip();

        }
    }
    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(raycast.position, transform.right * raycastLength, Color.red);
        }
        else if (distance < attackDistance)
        {
            Debug.DrawRay(raycast.position, transform.right * raycastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
    private bool Arealimit()
    {
        return transform.position.x > leftarea.position.x && transform.position.x < rightarea.position.x;
    }
    void ChooseTarget()
    {
        float distanceleftArea = Vector2.Distance(transform.position, leftarea.position);
        float distancerightArea = Vector2.Distance(transform.position, rightarea.position);
        if (distanceleftArea > distancerightArea)
        {
            target = leftarea;
        }
        else
        {
            target = rightarea;
        }
        Flip();
    }
    void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }

    public void TakenDmg(int dmg)
    {
        HP -= dmg;
        animation.Play("redflash");
    }
}
