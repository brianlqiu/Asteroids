using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCollisionHandler : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        InitializeSpaceship.spaceshipExists = false;
        Destroy(gameObject);
    }
}
