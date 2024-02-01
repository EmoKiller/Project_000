using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerControl playerControl;
    [SerializeField] Vector2 movementInput;
    public Vector2 MovementInput
    {
        get { return movementInput; }
    }
    private void Awake()
    {
    }
    private void OnEnable()
    {
        if (playerControl == null)
        {
            playerControl = new PlayerControl();

            playerControl.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            
        }
        playerControl.Enable();
    }
    private void OnDisable()
    {
        playerControl.Disable();
    }
    private void Update()
    {
        //Debug.Log(playerControl.PlayerMovement.Movement.actionMap);
    }
}
