using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveinput;


    Rigidbody2D rb;
    Animator animator;
    Animation anim;


    bool faceright = true;


    public float jumppow;
    bool grounded;
    bool jumpx2 = true;
    public Transform groundCheck;
    public LayerMask groundlayer;

    public HealthUI healthUI;
    public int presentHP;
    public int maxHP = 10;
  
  

    public GameScores gs;
    public Sounds sound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        
        gs = GameObject.FindWithTag("Gamescores").GetComponent<GameScores>();
        sound = GameObject.FindWithTag("sound").GetComponent<Sounds>();

        presentHP = maxHP;
        healthUI.maxhealth(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        //transform.Translate(xInput * moveinput * Time.deltaTime, 0, 0);//character move
        //rb.AddForce((Vector2.right) * moveinput * xInput);
        rb.velocity = new Vector2(xInput * moveinput, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(xInput));//animation character move

         if (xInput > 0 && !faceright)
         {
             Flip();
         }

         if (xInput < 0 && faceright)
         {
             Flip();
         }

        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundlayer);//check character stand on the grounded
        if (Input.GetKeyDown(KeyCode.W))//character jump with "space" and double jump
        {
            if (grounded)//If the character is on the ground then jumX2 = true then the character will jump once. then, we will check if the character is not on the ground then it will jump again and condition jumX2 = false because if jumX2 = true then the character will jump continuously.
            {

                jumpx2 = true;
                Jump();
            }
            else if (jumpx2)
            {
                jumpx2 = false;
                Jump();
            }
        }
        characterdie();
        
    }
    public void Jump()
    {
        rb.velocity = Vector2.up * jumppow;
    }
    public void characterdie()
    {
        if (presentHP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
    }
    public void EnemyDameged(int dame)
    {
        presentHP -= dame;
        healthUI.healthsetting(presentHP);
        DamegeEffect();
    }
     void DamegeEffect()
    {
        anim.Play("redflash");
    }
   public void Flip()
    {
        faceright = !faceright;
        transform.Rotate(0f, 180f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            sound.PlaySound("coins");
            Destroy(col.gameObject);
            gs.gold += 1;
        }
        
        if (col.gameObject.tag == "shoe")
        {
            Destroy(col.gameObject);
            moveinput += 7;
            StartCoroutine(countdowntime());
        }
    }
    IEnumerator countdowntime()
    {
        yield return new WaitForSeconds(3);
        moveinput = 4;
    }
}
