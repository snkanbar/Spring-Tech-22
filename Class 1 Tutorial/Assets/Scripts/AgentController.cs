using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject[] goalLoactions;
    // Start is called before the first frame update
    void Start()
    {
        goalLoactions = GameObject.FindGameObjectsWithTag("Goal");
        agent = this.GetComponent<NavMeshAgent>();
        int rand = Random.Range(0, goalLoactions.Length);
        agent.SetDestination(goalLoactions[rand].transform.position);
        float sm = Random.Range(0.1f, 1.5f); //step 4
        agent.speed = 5 * sm; //step4
    }

    // Update is called once per frame
    void Update()
    {
        //step 2

        if(agent.remainingDistance<1)
        {
            int rand = Random.Range(0, goalLoactions.Length);
            agent.SetDestination(goalLoactions[rand].transform.position);
        }
        
    }
}
