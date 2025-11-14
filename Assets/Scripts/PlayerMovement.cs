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

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPos.x = Mathf.Clamp(screenPos.x, 0f, Screen.width);
        screenPos.y = Mathf.Clamp(screenPos.y, 0f, Screen.height);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        transform.position = worldPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<EnemyMovement>().EnemyHit();
    }
}
