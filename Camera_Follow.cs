using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public GameObject Point_To_Follow;          //Point is attached to player(frog)
    public float max_transform_y_pos = 1.2f;    // A little crude version of movement clamping but for this game is ok :) 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position.y;
        pos = Mathf.MoveTowards(pos, Point_To_Follow.transform.position.y,2*Time.deltaTime); 
        pos = Mathf.Clamp(pos, (-0.5f), (max_transform_y_pos));
        transform.position = new Vector3(transform.position.x,pos,-10);
    }
}
