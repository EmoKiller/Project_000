using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        if (Input.GetMouseButtonDown(0))
        {
            GameUtilities.ScreenRayCastOnWorld(MoveDirection);
        }
        if (Input.GetMouseButton(1))
        {
            //Debug.DrawLine(transform.position, GameUtilities.ScreenRayCastOnWorld(), Color.blue);
            //Debug.DrawLine(transform.position, , Color.blue);
            agent.Raycast();
        }

    }
    private void FixedUpdate()
    {
        
    }
}
