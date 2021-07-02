using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform shootpoint;
    public float bulletspeed;
    public float firerate = 0.6f;

    public float nextfirereate;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shooting();
        }
    }
    public void Shooting()
    {
        if (nextfirereate <= Time.time)
        {
            GameObject bullet = Instantiate(bulletprefab, shootpoint.position, shootpoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletspeed;
            nextfirereate = Time.time + firerate;
        }
    }
    public void SetWeaponPrefab(GameObject newbullet)
    {
        bulletprefab = newbullet;
    }
}
