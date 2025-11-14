using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static event Action<Vector2> OnMoveInput;

    private void OnMove(InputValue inputValue)
    {
        OnMoveInput?.Invoke(inputValue.Get<Vector2>());
    }

    private void OnCancel(InputValue inputValue)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
