using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ayuda : MonoBehaviour
{
    [SerializeField] Transform meta;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        dqwe123();
    }
    public void dqwe123()
    {
        agent.SetDestination(new Vector3(meta.position.x, meta.position.y, meta.position.z));
    }
}
