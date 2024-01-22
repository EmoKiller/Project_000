using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBrain
{
    protected float horizontal => Input.GetAxis("Horizontal");
    protected float vertical => Input.GetAxis("Vertical");
    private void Update()
    {
        
    }
}
