
using UnityEngine;
using UnityEngine.Events;

public interface IMoveAble 
{
    MeshAgent agent { get; set; }
    Transform directionTarget { get; set; }
    void MoveDestination(Vector3 location, UnityAction action = null);
    void DashMoveDirection(Vector3 positon);
    void RotateDirection(Vector3 direction);

}
