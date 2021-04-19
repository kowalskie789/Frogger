using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    public GameObject[] zaby;
    public GameObject win_points;
    public float Time_to_open_next_lvl = 5;

    private bool Timer_Start = false; // might change for Couroutine later
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (zaby[0].activeSelf)
        {
            if (zaby[1].activeSelf)
            {
                if (zaby[2].activeSelf)
                {
                    Win();
                }
            }
        }


        if (Timer_Start)
        {
            Time_to_open_next_lvl -= Time.deltaTime;
        }
        if (Time_to_open_next_lvl <= 0)
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }
    public void Win()
    {
        GetComponent<Text>().enabled = true;
        win_points.gameObject.SetActive(true);
        Timer_Start = true;

    }
}
