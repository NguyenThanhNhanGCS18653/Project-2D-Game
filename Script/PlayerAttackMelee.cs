using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAttackMelee : MonoBehaviour
{

    public Animator animator;
    public Transform AttackPoint;
    public int dame = 3;

    public LayerMask enemyLayer;
    public LayerMask turretLayer;
    public LayerMask enemy2Layer;
    public LayerMask flyEnemy;
    public LayerMask enemy3;
    public LayerMask boss;
    public float firerate = 0.45f;
    private float nextfirerate;

    public Sounds sound;

    Collider2D[] dameFlyEnemy;
    Collider2D[] dameEnemise;
    Collider2D[] dameEnemise2;
    Collider2D[] dameEnemy3;
    Collider2D[] dameTurret;
    Collider2D[] dameBoss;
   
    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.FindWithTag("sound").GetComponent<Sounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sound.PlaySound("sword");
            Attacking();
        }
    }
    public void Attacking()
    {
        if (nextfirerate <= Time.time)
        {
            animator.SetTrigger("Attacking");//play attack animation


            dameTurret = Physics2D.OverlapCircleAll(AttackPoint.position, 1.5f, turretLayer);//range attack, attack point
            for (int i = 0; i < dameTurret.Length; i++)
            {
                dameTurret[i].GetComponent<TurretAI>().Damage(dame);
            }

            dameEnemise = Physics2D.OverlapCircleAll(AttackPoint.position, 1.5f, enemyLayer);
            for (int k = 0; k < dameEnemise.Length; k++)
            {
                dameEnemise[k].GetComponent<Enemy>().TakenDmg(dame);
            }

            dameEnemise2 = Physics2D.OverlapCircleAll(AttackPoint.position, 1.5f, enemy2Layer);
            for (int j = 0; j < dameEnemise2.Length; j++)
            {
                dameEnemise2[j].GetComponent<Enemy2>().TakenDame(dame);
            }

            dameFlyEnemy = Physics2D.OverlapCircleAll(AttackPoint.position, 1.5f, flyEnemy);
            for (int h = 0; h < dameFlyEnemy.Length; h++)
            {
                dameFlyEnemy[h].GetComponent<Fly_Enemy>().TakeDame(dame);
            }

            dameEnemy3 = Physics2D.OverlapCircleAll(AttackPoint.position, 1.5f, enemy3);
            for(int g = 0; g < dameEnemy3.Length; g++)
            {
                dameEnemy3[g].GetComponent<Enemy3>().TakenDmg(dame);
            }

            dameBoss = Physics2D.OverlapCircleAll(AttackPoint.position, 1.5f, boss);
            for(int l = 0; l < dameBoss.Length; l++)
            {
                dameBoss[l].GetComponent<Boss>().ApplyDmg(dame);
            }

            nextfirerate = firerate + Time.time;
        }
       
    }
    void OnDrawGizmosSelected()//Implement OnDrawGizmosSelected to draw a gizmo if the object is selected. Gizmos are drawn only when the object is selected.Gizmos are not pickable.This is used to ease setup. For example an explosion script could draw a sphere showing the explosion radius.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(AttackPoint.position, 0.7f);
    }
}
