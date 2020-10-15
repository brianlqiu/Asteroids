using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSoundManager : MonoBehaviour
{
    private AudioSource explosion;
    public static bool asteroidDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        explosion = GetComponent<AudioSource>();
        asteroidDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (asteroidDestroyed)
        {
            explosion.Play();
            asteroidDestroyed = false;
        }
    }
}
