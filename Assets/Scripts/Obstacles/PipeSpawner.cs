using Managers;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float offset = 5f;
    public float spawnInterval = 5f;
    public float squeezeLimit = 0.3f;
    private float _timer = 0f;
    private GameManager _gameManager;
    
    
    private void Start()
    {
        var obj = GameObject.FindGameObjectWithTag("GameManager");
        if (obj != null)
        {
            _gameManager = obj.GetComponent<GameManager>();
        }
        else
        {
            Debug.LogError("GameManager not found! Make sure it is tagged correctly.");
        }
        SpawnPipe();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_timer < spawnInterval)
        {
            _timer += Time.deltaTime * _gameManager.gameSpeed;
            return;
        }
        SpawnPipe();
        _timer = 0f;
        
    }

    private void SpawnPipe()
    {
        var newPipe = Instantiate(pipe, 
            new Vector3(
                transform.position.x, 
                Random.Range(transform.position.y - offset, transform.position.y + offset),
                transform.position.z
            ), 
            transform.rotation);

        if (squeezeLimit > 0)
        {
            Pipe pipeScript = newPipe.GetComponent<Pipe>();
            if (pipeScript != null)
            {
                float squeezeRate = Random.Range(0f, squeezeLimit);
                pipeScript.Squeeze(squeezeRate);
            }
            else
            {
                Debug.LogError("Pipe script not found on the spawned pipe!");
            }
        }
    }
}
