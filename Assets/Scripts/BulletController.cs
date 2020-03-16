using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if the object is on screen
        // Camera.main is whatever camera loads first
        // very useful

        if (Camera.main.WorldToViewportPoint(transform.position).y > 1)
        {
            scoreText.GetComponent<ScoreController>().score -= 5;
            scoreText.GetComponent<ScoreController>().UpdateScore();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject.Destroy(this.gameObject); // destroy bullet
            GameObject.Destroy(collision.gameObject); // destroy game object connected to what we collided with
            scoreText.GetComponent<ScoreController>().score += 10;
            scoreText.GetComponent<ScoreController>().UpdateScore();
        }
    }
}
