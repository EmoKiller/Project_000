using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MeshAgent : MonoBehaviour
{
    private NavMeshAgent _agent = null;
    public NavMeshAgent AgentBody => this.TryGetMonoComponent(ref _agent);
    public Vector3 LastPath = Vector3.zero;
    public float Speed
    {
        get { return AgentBody.speed; }
        set { AgentBody.speed = value; }
    }
    public bool IsMove = false;
    [Header("Debuger")]
    public bool ShowPath = true;
    public void MoveToDestination(Vector3 positon)
    {
        AgentBody.isStopped = false;
        LastPath = positon;
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
    public void RaycastReflect(Vector3 targetPosition)
    {
        if (AgentBody.Raycast(targetPosition, out NavMeshHit raycastHit))
        {
            if (raycastHit.hit)
            {
                float distance = Vector3.Distance(transform.position, targetPosition);
                float distanceReflect = distance - Vector3.Distance(transform.position, raycastHit.position);
                Debug.DrawLine(transform.position, raycastHit.position, Color.red);
                Debug.DrawLine(raycastHit.position, GameUtilities.MousePositionInWorld(), Color.blue);
                Vector3 reflectDirection = Vector3.Reflect(raycastHit.position - transform.position, raycastHit.normal);
                Debug.DrawRay(raycastHit.position, reflectDirection.normalized * distanceReflect, Color.red, 0.5f);
                return;
            }

        }
    }
    //IEnumerator CheckDestination(Func<bool> predicate)
    //{
    //    IsMove = true;
    //    yield return new WaitUntil(predicate);
    //    AgentBody.isStopped = true;
    //    IsMove = false;
    //}
    private void OnDrawGizmos()
    {
        if (!ShowPath || AgentBody.path == null)
            return;
        NavMeshPath paths = AgentBody.path;
        Gizmos.color = Color.red;
        for (int i = 0; i < paths.corners.Length - 1; i++)
        {
            Gizmos.DrawLine(paths.corners[i], paths.corners[i + 1]);
        }

    }

    
}
