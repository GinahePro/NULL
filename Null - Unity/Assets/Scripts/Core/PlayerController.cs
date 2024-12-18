using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput input;

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

    IEnumerator DelayStartup() { }

    private void OnOrientation(InputAction.CallbackContext ctx)
    {
        Quaternion inputValue = ctx.ReadValue<Quaternion>();
    }

    private void OnSwipe(InputAction.CallbackContext ctx)
    {
        Vector2 inputValue = ctx.ReadValue<Vector2>();
    }

}
