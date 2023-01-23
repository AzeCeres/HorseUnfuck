
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public Vector2 moveDirection { get; private set; }
    public void OnMove(InputValue value) => moveDirection = value.Get<Vector2>();
    public Vector2 lookVector { get; private set; }
    public void OnLook(InputValue value) => lookVector = value.Get<Vector2>();
    public float jump { get; private set; }
    public void OnJump(InputValue value) => jump = value.Get<float>();
    public bool jumpTrigger { get; private set; }
    public bool run { get; private set; }
    private void Update() {
        jumpTrigger = Keyboard.current.spaceKey.wasPressedThisFrame;
        run = Keyboard.current.shiftKey.isPressed;
    }

    

}
