using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat_Code : MonoBehaviour
{
    private string[] cheatCode;
    private int index;
    public GameObject Object_with_winning_script;
    // Start is called before the first frame update
    void Start()
    {
        cheatCode = new string[] { "w", "i", "n","n","e","r"};
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            if(Input.GetKeyDown(cheatCode[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
            if(index == cheatCode.Length)
            {
                Object_with_winning_script.GetComponent<Winning>().Win();
            }
        }
    }
}
