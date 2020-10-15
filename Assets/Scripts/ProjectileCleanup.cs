using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCleanup : MonoBehaviour
{
    private Rigidbody2D projectile;
    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (projectile.position.x < -15 || projectile.position.x > 15 || projectile.position.y > 7 || projectile.position.y < -7) Destroy(gameObject);
    }
}
