
using UnityEngine;
using UnityEngine.Events;

public interface IMoveAble 
{
    MeshAgent Agent { get; set; }
    Transform DirectionTarget { get; set; }
    void MoveDestination(Vector3 location, UnityAction action = null);
    void DashMoveDirection(Vector3 positon);
    void RotateDirection(Vector3 direction);

}
