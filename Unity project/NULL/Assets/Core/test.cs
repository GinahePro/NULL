using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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
