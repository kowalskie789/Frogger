using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line_Collider_Score : MonoBehaviour
{
    private float value;
    public GameObject Score;
    public GameObject Game_Controller;
    private void Start()
    {
        value = Game_Controller.GetComponent<Variables>().Score_for_movement;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Score.GetComponent<Score>().Score_value += value;

            gameObject.SetActive(false);
        }
    }
}

