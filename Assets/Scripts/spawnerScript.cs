using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject spawningPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        // random position in screen space
        float x = Random.Range(-9f, 9f);
        float y = Random.Range(-5f, 5f);

        Vector3 spawnPos = new Vector3(x, y, 0f);

        Instantiate(spawningPrefab, spawnPos, Quaternion.identity);
    }

}
