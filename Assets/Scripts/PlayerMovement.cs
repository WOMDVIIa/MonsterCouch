using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 lastReadMoveInput;
    [SerializeField] float moveSpeed;

    private void OnEnable()
    {
        InputManager.OnMoveInput += MovePlayer;
    }

    private void OnDisable()
    {
        InputManager.OnMoveInput -= MovePlayer;
    }

    void MovePlayer(Vector2 moveInput)
    {
        lastReadMoveInput = moveInput;        
    }

    private void Update()
    {
        transform.Translate(lastReadMoveInput * moveSpeed * Time.deltaTime);
    }
}
