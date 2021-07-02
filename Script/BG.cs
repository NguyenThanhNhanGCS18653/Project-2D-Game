using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public Player knight;
    Material m_material;
    // Start is called before the first frame update
    void Start()
    {
        m_material = GetComponent<Renderer>().material;
        knight = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 offset = m_material.mainTextureOffset;
        offset.x = knight.transform.position.x;
        m_material.mainTextureOffset = offset * Time.deltaTime ;
    }
}
