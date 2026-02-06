using UnityEngine;

public class pirateClock : MonoBehaviour
{
    public float clockDuration;

    private float timeWaiting = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeWaiting += Time.deltaTime * 1;

        if (timeWaiting > clockDuration)
        {
            timeWaiting = 0f;
            Debug.Log("Time is up");
        }

    }
}