using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : CharacterBrain
{
    public PlayerIdle PlayerIdle { get; private set; }

    public float Horizontal => Input.GetAxis("Horizontal");
    public float Vertical => Input.GetAxis("Vertical");
    [field: SerializeField] public virtual StateMachine<Player> StateMachine { get; set; }
    public override bool Alive => CurrentHealth > 0;
    private void Awake()
    {
        PlayerIdle = new PlayerIdle(this, StateMachine);
    }
    private void Start()
    {
        StateMachine.Initalize(PlayerIdle);
    }
    private void Update()
    {
        if (!Alive)
            return;
        StateMachine.CurrentEnemyState.FrameUpdate();
    }
}
