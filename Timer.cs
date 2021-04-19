using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float TimeForPassing;
    float time_left;
    public GameObject Score;
    public GameObject Game_Controller;
    // Start is called before the first frame update
    void Start()
    {
        TimeForPassing = Game_Controller.GetComponent<Variables>().Time_for_Passing_Lvl;
        time_left = TimeForPassing;    
    }

    // Update is called once per frame
    void Update()
    {
        time_left -= Time.deltaTime;
        GetComponent<Text>().text = time_left.ToString("0.0");
        if(time_left<=0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Frog>().Frog_Die();
        }
    }
    public void Reset_Timer()
    {
        time_left = TimeForPassing;
    }
    public void Reach_Goal()
    {
        Score.GetComponent<Score>().Score_value += (int)time_left * 100;
    }

}
