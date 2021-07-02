using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMove : MonoBehaviour
{
    public float speed = 2f;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        pos.x =pos.x + speed*Time.deltaTime;
        transform.position = pos;
    }
     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag=="Grass")
        {
            speed *= -1;
            
        }
    }
}
