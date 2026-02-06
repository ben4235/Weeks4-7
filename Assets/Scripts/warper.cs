using UnityEngine;
using UnityEngine.InputSystem;

public class warper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 currentMousePosition = Mouse.current.position.ReadValue();

            transform.position = currentMousePosition;

        }
    }
}
