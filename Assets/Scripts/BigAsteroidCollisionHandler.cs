using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroidCollisionHandler : MonoBehaviour
{
    [SerializeField] private Transform smallAsteroid;
    private Rigidbody2D bigAsteroid;

    void Start()
    {
        bigAsteroid = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        for (int i = 0; i < 4; i++)
        {
            float mult = Mathf.Floor(Random.Range(0f, 2f));
            mult = mult == 0f ? -1f : 1f;
            float x = Random.Range(-1f, 1f);
            float y = mult * Mathf.Sqrt(1 - Mathf.Pow(x, 2));
            Transform smallAsteroidInst = Instantiate(smallAsteroid, bigAsteroid.position, Quaternion.identity);
            Rigidbody2D smallAsteroidBody = smallAsteroidInst.GetComponent<Rigidbody2D>();
            smallAsteroidBody.AddForce(new Vector2(x * 1.5f, y * 1.5f), ForceMode2D.Impulse);
        }
        AsteroidSoundManager.asteroidDestroyed = true;
        ScoreUpdater.score += 100;
        ScoreUpdater.updateScore = true;
        Destroy(gameObject);
    }
}
