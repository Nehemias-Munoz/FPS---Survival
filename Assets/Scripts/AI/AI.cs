using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private GameObject destination;
    void Start()
    {
        _navMeshAgent.destination = destination.transform.position;
    }

    void Update()
    {
        
    }
}
