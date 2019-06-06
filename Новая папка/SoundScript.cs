using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip playerDeathSound;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        playerDeathSound = Resources.Load<AudioClip>("Death");

        audioSrc = GetComponent<AudioSource>();




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
        }
    }
}
