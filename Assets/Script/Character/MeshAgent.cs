using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UIElements;

public class MeshAgent : MonoBehaviour
{
    [SerializeField]private NavMeshAgent _agent = null;
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
    public void MoveToDirection(Vector3 direction)
    {
        AgentBody.Move(direction * Speed * Time.deltaTime);
    }
    public void MoveToDestination(Vector3 positon)
    {
        AgentBody.isStopped = false;
        LastPath = positon;
        AgentBody.SetDestination(positon);
    }
    public void SetSpeed(float valueSpeed)
    {
        Speed = valueSpeed;
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
