using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour
{
    
    public TurretAI turret;
    public bool isleft = false;
    // Start is called before the first frame update
    void Start()
    {
        
        turret = GetComponentInParent<TurretAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (isleft == false)
            {
                turret.Attack(true);
            }
            if (isleft == true)
            {
                turret.Attack(false);
            }
        }
    }
}
