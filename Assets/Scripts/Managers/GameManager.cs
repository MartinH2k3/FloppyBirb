using UnityEngine;
using Utilities;


namespace Managers
{

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // To make this singleton
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GameBounds.UpdateBounds(Camera.main);
        Debug.Log($"Game Bounds: Left: {GameBounds.Left}, Right: {GameBounds.Right}, Top: {GameBounds.Top}, Bottom: {GameBounds.Bottom}");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

}