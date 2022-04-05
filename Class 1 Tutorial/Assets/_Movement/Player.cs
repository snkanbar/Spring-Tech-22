using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float A = 0;
    public float B = 1;

    [Range(0,1)]
    public float T = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private Vector3 move = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        //float lerp = Mathf.Lerp(A, B, T);
        float speed = 0;
        float angle = 0;
        if (Input.GetKey(KeyCode.DownArrow)) { speed = -0.1f; }
        if (Input.GetKey(KeyCode.UpArrow)) { speed = 0.1f; }
        if (Input.GetKey(KeyCode.RightArrow)) { angle -= 1f; }
        if (Input.GetKey(KeyCode.LeftArrow)) { angle += 1f; }
        Vector3 move = this.transform.forward * speed;
        this.transform.Rotate(Vector3.up, angle); //this.transform.forward = forward;
        this.transform.Translate(move); //this.transform.position += move; //this.transform.position = move;
        //Debug.Log(T);
    }
}
