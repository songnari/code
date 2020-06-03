using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public Transform destinations;
    protected string tagName;

    NavMeshAgent agent;
    Transform[] targets;
    Transform target;
    int count;

    // Start is called before the first frame update
    protected void Start()
    {
        count = 1;
        agent = GetComponent<NavMeshAgent>();
        targets = destinations.transform.GetComponentsInChildren<Transform>();
        target = targets[count];

        for (int i = 2; i < targets.Length; i++)
            targets[i].gameObject.SetActive(false);

        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagName)
        {
            count++;
            if (count >= targets.Length)
                count = 1;
            
            target.gameObject.SetActive(false);
            target = targets[count];
            target.gameObject.SetActive(true);

            agent.SetDestination(target.position);
        }
    }

    public void setDes()
    {
        agent.SetDestination(target.position);
    }
}
