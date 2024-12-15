using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    [SerializeField] Transform camTransform;

    // Start is called before the first frame update
    void Start()
    {
        input.actionEvents[2].AddListener(onDelta);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onDelta(InputAction.CallbackContext ctx)
    {
        Vector2 inputValue = ctx.ReadValue<Vector2>();
        camTransform.Rotate(Vector3.up, inputValue.x/50,Space.World);
        camTransform.Rotate(Vector3.left, inputValue.y / 50, Space.Self);
    }

    void OnGravity(InputValue value)
    {
        Debug.Log(value.Get<Vector3>());
    }

    void OnTouch(InputValue value)
    {
        Debug.Log(value.ToString());
    }
}
