using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Player knight;
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Used()
    {
        Destroy(gameObject);
        knight.jumppow += 4;
    }
}
