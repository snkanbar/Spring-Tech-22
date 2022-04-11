using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float a = 0;
    public float b = 1;
    
    [Range(0, 1)]
    public float t = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Vector3 move = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        //float lerp = Mathf.Lerp(a, b, t);

        float speed = 0;
        float angle = 0;

        if (Input.GetKey(KeyCode.DownArrow)) {speed = -0.1f;}
        if (Input.GetKey(KeyCode.UpArrow)){speed = 0.1f; }
        if (Input.GetKey(KeyCode.RightArrow)){angle -= 1f;}
        if (Input.GetKey(KeyCode.LeftArrow)){ angle += 1f;}

        Vector3 move = this.transform.forward*speed;
        

        //this.transform.forward = forward;
        this.transform.Rotate(Vector3.up,angle);
        //this.transform.position += move;
        this.transform.Translate(move);
        //this.transform.position=move
        //Debug.Log(t);

    }
}
