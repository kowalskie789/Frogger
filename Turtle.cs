using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public GameObject Game_Controller;
    public Animator[] anim;
    public int Sinkingchance;
    private void Start()
    {
        Game_Controller = GameObject.FindGameObjectWithTag("GameController");
        Sinkingchance = Game_Controller.GetComponent<Variables>().Turtle_Sinking_Chance;
    }
    private void Update()
    {
        Destroy(gameObject, 25f);
       int x = Random.Range(0, Sinkingchance);
        
        if (x>=Sinkingchance-1)
        {
            foreach(Animator stuff in anim)
            {
                stuff.SetBool("Sink", true);
            }
        }
    }
    
}
