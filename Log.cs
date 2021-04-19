using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [HideInInspector]
    public GameObject Game_Controller;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    private Rigidbody2D rb;
    [HideInInspector]
    public bool Turtle_Sunk = false;
    // Start is called before the first frame update
    void Start()
    {
        Game_Controller = GameObject.FindGameObjectWithTag("GameController");
        speed = Game_Controller.GetComponent<Variables>().Speed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
        Destroy(gameObject, 25f);
    }
    public void Turtle_Die()
    {
        Destroy(transform.parent.gameObject, 1f);
        Turtle_Sunk = true;
    }
    
}

