using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshAgent : MonoBehaviour
{
    private NavMeshAgent _agent = null;
    public NavMeshAgent AgentBody => this.TryGetMonoComponent(ref _agent);

    private NavMeshPath path = null;

    [Header("Configuration")]
    public float moveSpeed = 1f;

    [Header("Debuger")]
    public bool ShowPath = true;
    public void Initialized()
    {
        path = new NavMeshPath();
    }
    public void MoveToDirection(Vector3 direction)
    {
        AgentBody.SetDestination(direction * moveSpeed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        if (!ShowPath || path == null)
            return;


    }
}
