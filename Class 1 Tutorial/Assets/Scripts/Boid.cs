using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public FlockManager Manager;
    public float Speed;
    private bool turning = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Speed = Random.Range(Manager.MinSpeed,Manager.MaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * Speed);        
    }

    public void BoidUpdate()
    {
        //containign box

        Bounds b = new Bounds(Manager.transform.position, Manager.Limits * 2);
        RaycastHit hit;
        Vector3 direction = Manager.transform.position - transform.position;
        Debug.DrawRay(this.transform.position, this.transform.forward * 2.5f, Color.red);

        if (!b.Contains(this.transform.position))
        {
            turning = true;

        }

        else if (Physics.Raycast(this.transform.position,this.transform.forward * 2.5f, out hit))
        {
            turning = true;
            direction = Vector3.Reflect(this.transform.forward,hit.normal);
        }

        else
        {
            turning = false;
        }

        if(turning)
        {
          
            Quaternion quat = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(this.transform.rotation, quat, Manager.RotationSpeed * Time.deltaTime);
            transform.Translate(0, 0, Time.deltaTime * Speed);
            return; //exit, end function
        }
        //Random speed behaviour
        if(Random.Range(0,100)<10) //10 percent chance speed will change
            Speed = Random.Range(Manager.MinSpeed, Manager.MaxSpeed);
        if (Random.Range(0, 100) > 20) //eighty percent chance
        {
            transform.Translate(0, 0, Time.deltaTime * Speed);
            return; //exit, end function
        }

            GameObject[] boids = Manager.boids; //what does manager do herre?

        Vector3 groupCenter = Vector3.zero; //1. 
        float groupSpeed = 0.01f;
        int groupSize = 0; //group distance //
        Vector3 avoid = Vector3.zero;

        //Flock calculation
        //1. Move to avg. grp of flock
        //2. Align with avg. heading direction
        //3. Avoid crowding with other flock members

        foreach(GameObject go in boids) // understand the logic the if statement how to read it
        {
            if (go == this.gameObject) { continue; }//skip next guard statement

            float distance = Vector3.Distance(go.transform.position, this.transform.position); //3.
            if (distance > Manager.NeighborDistance) { continue; }
           
            groupCenter += go.transform.position; //1.
            groupSize++; //1.

            if(distance<1.0f)
            {
                avoid += (this.transform.position - go.transform.position);
            }

            Boid boidscript = go.GetComponent<Boid>();
            groupSpeed += boidscript.Speed;

        }
        if(groupSize > 0)
        {
            groupCenter = groupCenter / groupSize + (Manager.GoalPos - this.transform.position); //average + goal
            groupSpeed = groupSpeed / groupSize; //average of all boids speed

            direction = (groupCenter + avoid) - this.transform.position;
            if(direction != Vector3.zero)
            {
                Quaternion quat = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(this.transform.rotation, quat, Manager.RotationSpeed * Time.deltaTime);
            }
        }
        transform.Translate(0, 0, Time.deltaTime * Speed);
    }
}
