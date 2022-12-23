using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    private GameObject[] destination;
    private int i = 0;
    private GameObject player;
    private float distanceToFollowPath = 5;
    private float distanceToPlayer;
    public float distanceToFollowPlayer = 10;
    void Start()
    {
        destination = GameObject.FindGameObjectsWithTag("DP");
        _navMeshAgent.destination = destination[0].transform.position;
        player = FindObjectOfType<playerMovement>().gameObject;
    }

    void Update()
    {
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