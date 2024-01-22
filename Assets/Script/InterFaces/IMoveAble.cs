
using UnityEngine;

public interface IMoveAble 
{
    MeshAgent agent { get; set; }
    Transform ObjectAnimationForRotation { get; set; }
    Transform directionTarget { get; set; }
    void MoveDirection(Vector3 location);

}
