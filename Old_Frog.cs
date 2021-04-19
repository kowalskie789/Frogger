using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Old_Frog : MonoBehaviour
{
    // This is old version of frog movement
    // Saved this for two reasons
    // To have backup if i mess up 
    // And to show that i care enough to rewrite code :P 
    private Rigidbody2D rb;
    public float SideJumpDebider = 0.25f;

    [HideInInspector]
    public bool Logride = false;

    [HideInInspector]
    public float speed = 0f;
    private float timer = 0.1f;

    private int lives = 3;
    public Image[] frog_lives;

    public GameObject time; // for reseting time after death;

    GameObject[] lines;  //Activating score lines after reaching goal
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        lines = GameObject.FindGameObjectsWithTag("Line");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Logride = false;
            rb.MovePosition(rb.position + Vector2.right * SideJumpDebider);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Logride = false;
            rb.MovePosition(rb.position + Vector2.left * SideJumpDebider);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Logride = false;
            rb.MovePosition(rb.position + Vector2.up * 0.79f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Logride = false;
            rb.MovePosition(rb.position + Vector2.down * 0.79f);
        }
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, (-5.3f), 6);
        pos.y = Mathf.Clamp(transform.position.y, (-3.55f), 10);
        transform.position = pos;
        // death!!!
        if (lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car")
        {

            Frog_Die();


        }
        if (collision.tag == "Goal")
        {
            collision.transform.GetChild(0).gameObject.SetActive(true);
            collision.GetComponent<BoxCollider2D>().enabled = false;
            time.GetComponent<Timer>().Reach_Goal();
            time.GetComponent<Timer>().Reset_Timer();
            //activating score colliders after reaching goal
            foreach (GameObject line in lines)
            {
                line.SetActive(true);
            }

            gameObject.transform.position = new Vector2(0, -3.55f);
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Water" && !Logride)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Frog_Die();
            }
        }

        if (collision.tag == "Log")
        {

            if (collision.transform.rotation.z == 0)
            {
                speed = collision.GetComponent<Log>().speed;
                Logride = true;
            }
            else
            {
                speed = -collision.GetComponent<Log>().speed;
                Logride = true;
            }


            if (collision.GetComponent<Log>().Turtle_Sunk == true)
            {
                Logride = false;
                Frog_Die();


            }

            else
            {
                timer = 0.1f;
            }
        }
    }
    public void Frog_Die()
    {
        frog_lives[lives - 1].gameObject.SetActive(false);
        lives--;
        time.GetComponent<Timer>().Reset_Timer();
        gameObject.transform.position = new Vector2(0, -3.55f);
    }
    private void FixedUpdate()
    {
        if (Logride)
        {

            rb.MovePosition(rb.position + speed * Vector2.right * Time.fixedDeltaTime);

        }
    }

}
