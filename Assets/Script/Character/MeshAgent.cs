using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;

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
    public void MoveToDirection(Vector3 positon)
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
    public void Raycast()
    {
        if (AgentBody.Raycast(GameUtilities.ScreenRayCastOnWorld(out Ray rays), out NavMeshHit raycastHit))
        {
            Vector3 reflectDirection = Vector3.Reflect(rays.direction, raycastHit.normal);
            Debug.DrawRay(raycastHit.position, reflectDirection * 10f, Color.red, 2f);

            Debug.DrawRay(transform.position, rays.direction, Color.blue);
            //if (raycastHit.hit)
            //{
            //    Debug.DrawLine(transform.position,raycastHit.position, Color.red);
            //}
        }
    }
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
