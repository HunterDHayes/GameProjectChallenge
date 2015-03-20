using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float liftForce;
    private Rigidbody2D rigid;
    private Collider2D col;
    private bool alive = true;
    private int score = 0;
    public Sprite[] playerSprtites;
    private bool once;
    public float waitTime;
    private float waitTimer;
    private float m_fTimeAlive;
    public Text m_Score;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        PlayerPrefs.SetInt("ChangingScenes", 1);

        int playerShip = PlayerPrefs.GetInt("PlayerChoice");
        GetComponent<SpriteRenderer>().sprite = playerSprtites[playerShip];
        //orange,blue,pink,green
        waitTimer = waitTime;
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        m_fTimeAlive += Time.deltaTime;
        m_Score.text = "Score: " + score;

        if (once == false && Input.GetMouseButton(0) || waitTime < 0.0f)
        {
            rigid.gravityScale = 1.0f;
            once = true;
        }
        //input
        if (transform.position.y < -7.0f)
        {
            Application.LoadLevel("GameOver");
            PlayerPrefs.SetInt("ChangingScenes", 0);

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Main Menu");
            PlayerPrefs.SetInt("ChangingScenes", 0);
        }


    }
    void FixedUpdate()
    {
        if (alive)
        {
            if (Input.GetMouseButton(0))
            {
                rigid.AddForce(new Vector2(0, (liftForce * Time.deltaTime)));
            }
        }
        if (once == false)
        {

            rigid.gravityScale = 0.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit something");
    }

    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.tag == "Cloud")
        {
            Debug.Log("hit a cloud");
            Death();
        }
        else if (collided.tag == "Obstacle")
        {
            Debug.Log("hit an obstacle");
            Death();
        }
        else if (collided.tag == "PickUp")
        {
            Debug.Log("hit a PickUp");
            Destroy(collided.transform.gameObject);
            score += 25;
        }
        else
        {
            Debug.Log("triggered something");
        }
    }

    void Death()
    {

        if (alive)
        {
            rigid.AddForce(new Vector2(0, -50));
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.SetInt("TotalPlaythroughs", PlayerPrefs.GetInt("TotalPlaythroughs") + 1);
            GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

            if (soundManager)
                soundManager.SendMessage("PlaySfx", "Death");

            alive = false;

            PlayerPrefs.SetFloat("Time", m_fTimeAlive);

            if (score > PlayerPrefs.GetInt("Highscore"))
                PlayerPrefs.SetInt("Highscore", score);

            if (m_fTimeAlive > PlayerPrefs.GetFloat("LongestPlayTime"))
                PlayerPrefs.SetFloat("LongestPlayTime", m_fTimeAlive);
        }
    }

    void OnDestroy()
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        if (soundManager)
            soundManager.SendMessage("StopAllMusic");
    }
}
