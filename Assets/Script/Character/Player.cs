using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBrain
{
    protected float horizontal => Input.GetAxis("Horizontal");
    protected float vertical => Input.GetAxis("Vertical");
    public override bool Alive => CurrentHealth > 0;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CurrentHealth = 0;
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameUtilities.ScreenRayCastOnWorld(MoveDirection);
        }

    }
    private void FixedUpdate()
    {
        
    }
}
