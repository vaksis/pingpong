using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField]
    private float speed;
    private float radius;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        // aloitussuunta suoraan
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            // tarkistetaan onko maila oikea vai vasen
            bool isRight = other.GetComponent<Paddle>().isRight;
            if (isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // liikutetaan palloa
        transform.Translate(direction * speed * Time.deltaTime);
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
            speed++;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
            speed++;
        }

        // tarkistetaan voittiko pelaaja
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Oikea pelaaja voitti!");
            Time.timeScale = 0;
            // lopetetaan skriptin suoritus
            enabled = false;
        }
        else if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Vasen pelaaja voitti!");
            Time.timeScale = 0;
            // lopetetaan skriptin suoritus
            enabled = false;
        }

    }
}
