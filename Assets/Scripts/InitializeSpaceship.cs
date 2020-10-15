using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeSpaceship : MonoBehaviour
{ 
    [SerializeField] private Transform spaceship;
    [SerializeField] private GameObject life1;
    [SerializeField] private GameObject life2;
    [SerializeField] private GameObject life3;

    private int lives;
    private AudioSource spaceshipExplosion;
    public static bool spaceshipExists = true;

    // Start is called before the first frame update
    void Start()
    {
        lives = 4;
        Instantiate(spaceship, new Vector2(0f, 0f), Quaternion.identity);
        spaceshipExists = true;
        spaceshipExplosion = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!spaceshipExists)
        {
            spaceshipExplosion.Play();
            lives--;
            spaceshipExists = true;
            if (lives == 0)
            {
                GameOverDisplayer.gameOver = true;
            } 
            else
            {
                switch (lives)
                {
                    case 3:
                        Destroy(life1);
                        break;
                    case 2:
                        Destroy(life2);
                        break;
                    case 1:
                        Destroy(life3);
                        break;
                }
                StartCoroutine(InstantiateListener());
            }
        }
    }

    IEnumerator InstantiateListener()
    {
        yield return new WaitForSeconds(2);
        Instantiate(spaceship, new Vector2(0f, 0f), Quaternion.identity);
    }
}
