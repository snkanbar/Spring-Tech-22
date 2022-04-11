using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInstantiator : MonoBehaviour
{
    public GameObject Prefab;
    private FlockManager _flockmanager;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Click");
            Instantiate(Prefab,this.transform.position, Quaternion.identity);

        }

       
    }
}
