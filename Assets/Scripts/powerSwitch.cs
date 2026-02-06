using UnityEngine;

public class powerSwitch : MonoBehaviour
{
    void Start()
    {
        
    }

    public float speed;

    void Update()
    {
        transform.eulerAngles += new Vector3(0f, 0f, speed * Time.deltaTime);
    }

    public void StartSpin()
    {
        speed = 100f;
    }

    public void StopSpin()
    {
        speed = 0f;
    }
}
