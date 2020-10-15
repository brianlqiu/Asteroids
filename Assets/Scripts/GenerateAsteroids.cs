using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroids : MonoBehaviour
{

    [SerializeField] private Transform bigAsteroid;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchAsteroid", 0.5f, 2f);
    }

    void LaunchAsteroid()
    {
        float side = Mathf.Floor(Random.Range(0f, 3.999f));
        Vector2 start;
        Vector2 end;
        switch (side)
        {
            case 0f:    // Left side
                start = new Vector2(-12f, Random.Range(-5f, 5f));
                end = new Vector2(12f, Random.Range(-5f, 5f));
                break;
            case 1f:    // Right side
                start = new Vector2(12f, Random.Range(-5f, 5f));
                end = new Vector2(-12f, Random.Range(-5f, 5f));
                break;
            case 2f:    // Upper side
                start = new Vector2(Random.Range(-12f, 12f), 5f);
                end = new Vector2(Random.Range(-12f, 12f), -5f);
                break;
            case 3f:
                start = new Vector2(Random.Range(-12f, 12f), -5f);
                end = new Vector2(Random.Range(-12f, 12f), 5f);
                break;
            default:
                start = new Vector2(-15f, -15f);
                end = new Vector2(-15f, -15f);
                break;
        }
        Transform bigAsteroidInst = Instantiate(bigAsteroid, start, Quaternion.identity);
        Rigidbody2D bigAsteroidBody = bigAsteroidInst.GetComponent<Rigidbody2D>();
        bigAsteroidBody.AddForce(new Vector2((end.x - start.x) * 0.05f, (end.y - start.y) * 0.05f), ForceMode2D.Impulse);
    }
}
