using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // esitellään julkiset muuttujat
    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // luodaan pallo
        Instantiate(ball);

        // luodaan kaksi mailaa
        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        // lisätään mailalle kohta boolean-arvo
        // joka kertoo onko se oikea vai vasen
        paddle1.Init(true);
        paddle2.Init(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
