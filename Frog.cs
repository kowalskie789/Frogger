using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Frog : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;
    public float SideJumpDebider = 0.5f;  // Frog jumps horizontally seemded akward and iritating to me so i've cut them a little 
    public AudioSource jumpsound;
    public AudioSource death;
    [HideInInspector]
    public bool Logride = false;

    [HideInInspector]
    public float speed = 0f;
    

    private int lives = 3;
    public Image[] frog_lives;

    public GameObject time; // for reseting time after death;
    private Vector3 dir;
        GameObject[] lines;  //Activating score lines after reaching goal
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsound = GetComponent<AudioSource>();
        

        dir = rb.transform.position;
        lines = GameObject.FindGameObjectsWithTag("Line");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Logride = false;                                                                                    //for chceck if frog is rifing on the log

            anim.SetBool("Jump", true);                                                                         //standard animator stuff
            jumpsound.Play();

            dir = (rb.position + Vector2.right * SideJumpDebider);                                              //movement direction, movement itself is in FixedUpdate down below
           
             rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.Euler(0,0,-270), 1);    //FRAS - frog Rotation Algorihm Stuf
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Logride = false;

            anim.SetBool("Jump", true);
            jumpsound.Play();
            dir = (rb.position + Vector2.left * SideJumpDebider);
            
            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.Euler(0, 0, -90), 1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Logride = false;

            anim.SetBool("Jump", true);
            jumpsound.Play();
            dir = (rb.position + Vector2.up * 0.79f);
            
            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.Euler(0, 0, -180), 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Logride = false;

            anim.SetBool("Jump", true);
            jumpsound.Play();
            dir = (rb.position + Vector2.down * 0.79f);
           
            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.Euler(0, 0, 0), 1);
        }

        //movement clampng 
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, (-5.3f), 6);
        pos.y = Mathf.Clamp(transform.position.y, (-3.55f), 10);
        transform.position = pos;
        //end of movement clamping

        if (lives == 0)
        {
            SceneManager.LoadScene(0);
            
        }

       
        
    }
    private void Surface_Check() // Second version of my surface chceck
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(transform.position, Camera.main.transform.forward);
        foreach (RaycastHit2D col in hit)
        {

            if (col.collider.tag == "Car")
            {
                Frog_Die();

            }
            if (col.collider.tag == "Goal")
            {
                col.collider.transform.GetChild(0).gameObject.SetActive(true);
                col.collider.GetComponent<BoxCollider2D>().enabled = false;
                time.GetComponent<Timer>().Reach_Goal();
                time.GetComponent<Timer>().Reset_Timer();
                //activating score colliders after reaching goal
                foreach (GameObject line in lines)
                {
                    line.SetActive(true);
                }

                gameObject.transform.position = new Vector2(0, -3.55f);
                dir = rb.transform.position;
            }
            if (col.collider.tag == "Log")
            {

                if (col.collider.transform.rotation.z == 0)
                {
                    speed = col.collider.GetComponent<Log>().speed;
                    Logride = true;
                }
                else
                {
                    speed = -col.collider.GetComponent<Log>().speed;
                    Logride = true;
                }


                if (col.collider.GetComponent<Log>().Turtle_Sunk == true)
                {
                    Logride = false;
                    Frog_Die();
                }
                break;
            }
            if (col.collider.tag == "Water")
            {
                bool WetFrog = false;
                foreach (RaycastHit2D x in hit)
                {
                    if (x.collider.tag == "Log")
                    {
                        WetFrog = false;
                    }
                    else
                    {
                        WetFrog = true;
                    }

                }
                if (WetFrog)
                {
                    Frog_Die();
                }
            }
        }
    }
    public void Frog_Die()
    {
        death.Play();
        Logride = false;
        frog_lives[lives - 1].gameObject.SetActive(false);
        lives--;
        time.GetComponent<Timer>().Reset_Timer();
        gameObject.transform.position = new Vector2(0, -3.55f);
        dir = gameObject.transform.position;
    }
    private void FixedUpdate()
    {
        if (Logride)
        {
            Surface_Check();
            rb.MovePosition(rb.position + speed * Vector2.right * Time.fixedDeltaTime);

        }
        else
        {
            rb.position = Vector3.MoveTowards(rb.transform.position,dir,4*Time.fixedDeltaTime);
        }
        if(rb.transform.position == dir)
        {
            anim.SetBool("Jump", false);
            Surface_Check(); 
        }
    }

}
