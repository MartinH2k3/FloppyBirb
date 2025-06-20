using UnityEngine;
using Utilities;

public class Pipe : MonoBehaviour
{
    public float speed = 5f;

    private Transform _pipeTop;
    private Transform _pipeBottom;
    
    private BoxCollider2D _boxColliderTop;
    private BoxCollider2D _boxColliderBottom;
    
    private void Awake()
    {
        _pipeTop = transform.Find("pipe_top");
        _pipeBottom = transform.Find("pipe_bottom");
        
        if (_pipeTop != null)
        {
            _boxColliderTop = _pipeTop.GetComponent<BoxCollider2D>();
            if (_boxColliderTop == null)
            {
                Debug.LogError("BoxCollider2D not found on pipe_top!");
            }
        }
        
        if (_pipeBottom != null)
        {
            _boxColliderBottom = _pipeBottom.GetComponent<BoxCollider2D>();
            if (_boxColliderBottom == null)
            {
                Debug.LogError("BoxCollider2D not found on pipe_bottom!");
            }
        }
        
        if (_pipeTop == null || _pipeBottom == null)
        {
            Debug.LogError("Pipe parts not found! Check child names.");
        }
    }
    
    private void Start()
    {
        Debug.Log($"Pipe Position: {transform.position.x}, Game Bounds Left: {GameBounds.Left}");
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
        //if (transform.position.x < GameBounds.Left) Destroy(gameObject);
    }

    
    // between 0 and 1
    public void Squeeze(float rate)
    {
        if (rate is < 0f or > 1f)
        {
            Debug.LogError("Squeeze rate must be between 0 and 1.");
            return;
        }
        
        // bottom of top pipe - top of bottom pipe
        var gap = _boxColliderTop.bounds.min.y - _boxColliderBottom.bounds.max.y;
        // how much each of them needs to move closer to the other
        var squeezeAmount = (gap - gap * rate)/2;
        
        _pipeTop.position = new Vector3(_pipeTop.position.x, _pipeTop.position.y - squeezeAmount, _pipeTop.position.z);
        _pipeBottom.position = new Vector3(_pipeBottom.position.x, _pipeBottom.position.y + squeezeAmount, _pipeBottom.position.z);
    }
    
    
}
