using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroidCollisionHandler : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        AsteroidSoundManager.asteroidDestroyed = true;
        ScoreUpdater.score += 25;
        ScoreUpdater.updateScore = true;
        Destroy(gameObject);
    }
}
