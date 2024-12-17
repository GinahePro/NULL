using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private Transform camTransform;

    // Start is called before the first frame update
    void Start()
    {
        input.actionEvents[1].AddListener(OnSwipe);
    }

    // Update is called once per frame
    void Update()
    {
        if (AttitudeSensor.current == null)
        {
            Debug.Log("Not connected");
        }
        else
        {
            if (!AttitudeSensor.current.enabled)
            {
                Debug.Log("Enabling Attitude sensor");
                InputSystem.EnableDevice(AttitudeSensor.current);
                Debug.Log("Subscribing to event");
                Debug.Log(input.actionEvents);
                input.actionEvents[0].AddListener(OnOrientation);

            }
        }
    }

    private void OnOrientation(InputAction.CallbackContext ctx)
    {
        Quaternion inputValue = ctx.ReadValue<Quaternion>();
        Debug.Log(inputValue);
        Debug.Log(Screen.orientation);
    }

    private void OnSwipe(InputAction.CallbackContext ctx)
    {
        Vector2 inputValue = ctx.ReadValue<Vector2>();
        camTransform.Rotate(Vector3.up, inputValue.x/50,Space.World);
        camTransform.Rotate(Vector3.left, inputValue.y / 50, Space.Self);
    }

}
