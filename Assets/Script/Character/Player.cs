using Unity.VisualScripting;
using UnityEngine;

public class Player : CharacterBrain
{
    [SerializeField] private CameraFollow cameraFollow;
    public PlayerIdle PlayerIdle { get; private set; }
    public InputManager InputManager { get; private set; }
    [field: SerializeField] public StateMachine<Player> StateMachine { get; private set; }
    public override bool Alive => CurrentHealth > 0;
    private void Awake()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
        InputManager = GetComponent<InputManager>();
        StateMachine = new StateMachine<Player>();
        PlayerIdle = new PlayerIdle(this, StateMachine);

    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StateMachine.Initalize(PlayerIdle);
    }
    private void Update()
    {
        if (!Alive)
            return;
        StateMachine.CurrentState.FrameUpdate();
    }
    public Vector2 MovementInput()
    {
        return InputManager.MovementInput;
    }
    public void PlayerMove() 
    {
        if (MovementInput().x != 0 || MovementInput().y != 0)
        {
            Vector3 vec = CameraFollow.instance.transform.forward;
            vec.y = 0;
            Vector3 move = vec.normalized * (MovementInput().y * Time.deltaTime) + CameraFollow.instance.transform.right * (MovementInput().x * Time.deltaTime);
            Agent.MoveToDirection(move) ;
            CharacterAnimator.SetFloat("Vertical",1);
        }
        if (MovementInput().y == 0)
        {

        }
    }
}
