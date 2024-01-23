using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshAgent : MonoBehaviour
{
    private NavMeshAgent _agent = null;
    public NavMeshAgent AgentBody => this.TryGetMonoComponent(ref _agent);
    [SerializeField]private NavMeshPath path = null;
    public float Speed
    {
        get { return AgentBody.speed; }
        set { AgentBody.speed = value; }
    }
    [Header("Debuger")]
    public bool ShowPath = true;
    public void Initialized()
    {
        path = new NavMeshPath();
    }
    public void MoveToDirection(Vector3 positon)
    {
         AgentBody.SetDestination(positon); 
    }
    public void SetObstacleAvoidance(ObstacleAvoidanceType type)
    {
        AgentBody.obstacleAvoidanceType = type;
    }
    public void SetSpeed(float valueSpeed)
    {
        Speed = valueSpeed;
    }
    private void OnDrawGizmos()
    {
        if (!ShowPath || path == null)
            return;
        for (int i = 0; i < AgentBody.path.corners.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, AgentBody.path.corners[i]);
        }

    }
}
