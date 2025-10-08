using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    // This class needs to be a singleton
    public static PlayerController Instance { get; private set; }

    public UnityEvent onJump;

    private Player_Actions _playerActions;

    private void Awake()
    {
        // Destroy the instance if there is an instance of this class
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        _playerActions = new Player_Actions();

        // Setup all kind of input actions down here
        _playerActions.Player.Jump.started += _ => onJump?.Invoke(); // This is an anonymous function
    }

    private void OnEnable()
    {
        _playerActions.Enable();
        _playerActions.Player.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Disable();
        _playerActions.Player.Disable();
    }
}
