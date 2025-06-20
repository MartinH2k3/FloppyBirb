using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float offset = 5f;
    public float spawnInterval = 5f;
    private float _timer = 0f;
    
    private void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_timer < spawnInterval)
        {
            _timer += Time.deltaTime;
            return;
        }
        SpawnPipe();
        _timer = 0f;
        
    }

    private void SpawnPipe()
    {
        Instantiate(pipe, 
            new Vector3(
                transform.position.x, 
                Random.Range(transform.position.y - offset, transform.position.y + offset),
                transform.position.z
            ), 
            transform.rotation);
    }
}
