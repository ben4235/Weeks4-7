using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class objectIdentification : MonoBehaviour
{
    public bool isHovering;
    public bool shouldTurnOn;
    public bool shouldTurnOff;
    public GameObject warperObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            isHovering = true;
        }
        else
        {
            isHovering = false;
        }
        bool onHover = !warperObject.activeInHierarchy;
        bool offHover = warperObject.activeInHierarchy;

        if (shouldTurnOn == true)
        {
            warperObject.SetActive(true);
        }

        if (shouldTurnOff)
        {
            warperObject.SetActive(false);
        }
    }
}
