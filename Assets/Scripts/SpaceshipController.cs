using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    private Rigidbody2D spaceship;
    [SerializeField] private AudioSource thrusters;
    [SerializeField] private AudioSource firing;
    private const float MAX_SPEED = 4f;

    private Transform barrelEndPointTransform;
    
    [SerializeField] private Transform bullet;

    // Start is called before the first frame update
    void Start()
    {
        spaceship = GetComponent<Rigidbody2D>();
        barrelEndPointTransform = this.gameObject.transform.GetChild(0);
    }

    Vector2 GetForceVectorFromRotation(float multiplier)
    {
        return new Vector2(Mathf.Cos((spaceship.rotation + 90) * Mathf.Deg2Rad) * multiplier, Mathf.Sin((spaceship.rotation + 90) * Mathf.Deg2Rad) * multiplier);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("j"))
        {
            spaceship.rotation += 200f * Time.deltaTime;
        }

        if (Input.GetKey("l"))
        {
            spaceship.rotation -= 200f * Time.deltaTime;
        }

        if (Input.GetKey("k"))
        {
            print(spaceship.velocity.magnitude);
            if (spaceship.velocity.magnitude < MAX_SPEED)
                spaceship.AddForce(GetForceVectorFromRotation(0.1f), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown("k"))
        {
            thrusters.Play();
        }

        if (Input.GetKeyUp("k"))
        {
            thrusters.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            firing.Play();
            Transform bulletInst = Instantiate(bullet, barrelEndPointTransform.position, Quaternion.identity);
            Rigidbody2D bulletBody = bulletInst.GetComponent<Rigidbody2D>();
            bulletBody.AddForce(GetForceVectorFromRotation(5f), ForceMode2D.Impulse);
        }
    }
}
