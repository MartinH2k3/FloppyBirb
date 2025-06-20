using System;
using Managers;
using UnityEngine;

public class GapTrigger : MonoBehaviour
{

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3) _gameManager.AddScore();
    }
}
