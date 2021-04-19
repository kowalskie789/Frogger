using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [HideInInspector]
    public float Score_value;  
    public Text Score_Text;
    public Text Score_Text_2;
    // Start is called before the first frame update
    void Start()
    {
        Score_Text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Score_Text.text = Score_value.ToString();
        Score_Text_2.text = Score_Text.text + " POINTS";
    }
}
