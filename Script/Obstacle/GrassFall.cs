using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassFall : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    
}
