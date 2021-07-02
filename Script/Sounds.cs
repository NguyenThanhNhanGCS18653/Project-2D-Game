using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sounds : MonoBehaviour
{
    public AudioClip coin, destroyenemy, sword;
   
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        destroyenemy = Resources.Load<AudioClip>("RockCrash");
        sword = Resources.Load<AudioClip>("Sword");
        coin = Resources.Load<AudioClip>("Gamecoin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case ("coins"):
                audioSource.clip = coin;
                audioSource.PlayOneShot(coin, 0.6f);
                break;

            case ("destroy"):
                audioSource.clip = destroyenemy;
                audioSource.PlayOneShot(destroyenemy, 1f);
                break;

            case ("sword"):
                audioSource.clip = sword;
                audioSource.PlayOneShot(sword, 1f);
                break;

        }
    }
}
