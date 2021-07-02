using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxHp : MonoBehaviour
{
    Player knight;
    
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Used()
    {
        Destroy(gameObject);
        knight.presentHP += 5;
        
    }
}
