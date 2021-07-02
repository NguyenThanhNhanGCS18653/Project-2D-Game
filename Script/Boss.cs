using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Idel")]
    public float idelMovementSpeed;
    [SerializeField] Vector2 idelMovementDirection;

    [Header("AttackUpNDown")]
    [SerializeField] float attackMovementSpeed;
    [SerializeField] Vector2 attackMovementDirection;

    [Header("AttackPlayer")]
    [SerializeField] float attackPlayerSpeed;
    [SerializeField] Transform player;

    [Header("Other")]
    [SerializeField] Transform goundCheckUp;
    [SerializeField] Transform goundCheckDown;
    [SerializeField] Transform goundCheckWall;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;
    private bool hasPlayerPositon;

    private Vector2 playerPosition;

    private bool facingLeft = true;
    private bool goingUp = true;
    private Rigidbody2D enemyRB;
    private Animator enemyAnim;
    Player knight;
    Animation anim;
    public int HP = 50;

    public Transform attackpoint;
    public LayerMask Dmgplayer;
    Collider2D[] dameKnight;
    void Start()
    {
        anim = GetComponent<Animation>();
        knight = GetComponent<Player>();
        idelMovementDirection.Normalize();
        attackMovementDirection.Normalize();
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingUp = Physics2D.OverlapCircle(goundCheckUp.position, groundCheckRadius, groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(goundCheckDown.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(goundCheckWall.position, groundCheckRadius, groundLayer);

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void RandomStatePicker()
    {
        int randomState = Random.Range(0, 2);
        if (randomState == 0)
        {
            enemyAnim.SetTrigger("AttackUpDown");
        }
        else if (randomState == 1)
        {
            enemyAnim.SetTrigger("AttackKnight");
        }
    }

    public void IdleState()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }

        if (isTouchingWall)
        {
            if (facingLeft)
            {
                Flip();
            }
            else if (!facingLeft)
            {
                Flip();
            }
        }
        enemyRB.velocity = idelMovementSpeed * idelMovementDirection;
    }
    public void AttackUpNDownState()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }

        if (isTouchingWall)
        {
            if (facingLeft)
            {
                Flip();
            }
            else if (!facingLeft)
            {
                Flip();
            }
        }
        AttackDmg();
        enemyRB.velocity = attackMovementSpeed * attackMovementDirection;
    }

    public void AttackPlayerState()
    {

        if (!hasPlayerPositon)
        {
            FlipTowardsPlayer();
            playerPosition = player.position - transform.position;
            playerPosition.Normalize();
            hasPlayerPositon = true;
        }

        if (hasPlayerPositon)
        {
            enemyRB.velocity = attackPlayerSpeed * playerPosition;
        }

        if (isTouchingWall || isTouchingDown)
        {
            //play Slam animation
            enemyAnim.SetTrigger("Boss_creep");
            enemyRB.velocity = Vector2.zero;
            hasPlayerPositon = false;
        }
        AttackDmg();
    }

    void FlipTowardsPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;

        if (playerDirection > 0 && facingLeft)
        {
            Flip();
        }
        else if (playerDirection < 0 && !facingLeft)
        {
            Flip();
        }
    }

    void ChangeDirection()
    {
        goingUp = !goingUp;
        idelMovementDirection.y *= -1;
        attackMovementDirection.y *= -1;
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        idelMovementDirection.x *= -1;
        attackMovementDirection.x *= -1;
        transform.Rotate(0, 180, 0);
    }

    void AttackDmg()
    {
        dameKnight = Physics2D.OverlapCircleAll(attackpoint.position, 0.75f, Dmgplayer);
        for(int i = 0; i < dameKnight.Length; i++)
        {
            dameKnight[i].GetComponent<Player>().EnemyDameged(3);
        }
    }
    public void ApplyDmg(int dmg)
    {
        HP -= dmg;
        anim.Play("redflash");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(goundCheckUp.position, groundCheckRadius);
        Gizmos.DrawWireSphere(goundCheckDown.position, groundCheckRadius);
        Gizmos.DrawWireSphere(goundCheckWall.position, groundCheckRadius);
    }
}