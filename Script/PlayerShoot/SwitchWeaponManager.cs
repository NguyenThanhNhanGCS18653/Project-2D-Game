using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeaponManager : MonoBehaviour
{
    public GameObject thunderprefab;
    public GameObject windprefab;


    public GameObject swordlightPrefab;
    public GameObject darkprefab;


    PlayerShooting knightShoot;
    // Start is called before the first frame update
    void Start()
    {
        knightShoot = GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeaponID(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeaponID(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeaponID(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetWeaponID(4);
        }
    }
    void SetWeaponID(int ID)
    {
        switch (ID)
        {
            case 1:
                knightShoot.SetWeaponPrefab(thunderprefab);
                break;
            case 2:
                knightShoot.SetWeaponPrefab(swordlightPrefab);
                break;
            case 3:
                knightShoot.SetWeaponPrefab(darkprefab);
                break;
            case 4:
                knightShoot.SetWeaponPrefab(windprefab);
                break;
        }
    }
}
