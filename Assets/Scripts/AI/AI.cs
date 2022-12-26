using System;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    private GameObject[] destination;
    private int i = 0;
    private GameObject player;
    private float distanceToFollowPath = 3;
    private float distanceToPlayer;
    public float distanceToFollowPlayer = 12;
    //Efectos
    [SerializeField] private GameObject explosionEffect;


    public Animator Animator;
    
    
    void Start()
    {
        destination = GameObject.FindGameObjectsWithTag("DP");
        _navMeshAgent.destination = destination[0].transform.position;
        player = FindObjectOfType<playerMovement>().gameObject;
    }

    void Update()
    {
        Animator.SetFloat("VelX", transform.position.x);
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= distanceToFollowPlayer)
        {
            FollowPlayer();
        }
        else
        {
            EnemyPath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Data.SetLives(Data.GetLives()-1);
        }
    }
    public void Kill()
    {
        Data.SetScore(Data.GetScore() + 100);
        var explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(explosion, 1);
    }
    void EnemyPath()
    {
        _navMeshAgent.destination = destination[i].transform.position;
        if (Vector3.Distance(transform.position, destination[i].transform.position) < distanceToFollowPath )
        {
            i = destination[i] != destination[destination.Length - 1] ? i++ : i = 0;
        }
    }

    void FollowPlayer()
    {
        _navMeshAgent.destination = player.transform.position;
    }
}
