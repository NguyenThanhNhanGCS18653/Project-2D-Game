using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
   // BulletPlayer bulletPlayer;
    //PlayerAttackMelee attackMelee;
    public Player knight;
    // Start is called before the first frame update
    void Start()
    {
        //attackMelee = GetComponent<PlayerAttackMelee>();
        //bulletPlayer = GameObject.FindGameObjectWithTag("bulletplayer").GetComponent<BulletPlayer>();
        knight = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Used()
    {
        Destroy(gameObject);
        if (knight.presentHP > knight.maxHP)
        {
            knight.presentHP = knight.maxHP;
        }
        else
        {
            knight.presentHP += 1;
        }
    }
   /* public void Use()
    {
        Destroy(gameObject);
        bulletPlayer.dmg += 5;
    }*/
   /*public void qwe()
    {
        Destroy(gameObject);
        attackMelee.dame += 8;
    }*/
}
