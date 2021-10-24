using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCControl : MonoBehaviour
{   
    NavMeshAgent agent;
    public GameObject target;
    public bool reached = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
        InvokeRepeating("AIDestination",0.5f,0.5f);
    }
    void AIDestination()
      {
        agent.SetDestination(target.transform.position);
      }
    // Update is called once per frame
    void Update()
    {
        
    }
}
