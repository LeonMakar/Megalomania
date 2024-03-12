using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;


    public void SetNewPosition(Vector3 position)
    {
        agent.SetDestination(position);

    }
}
