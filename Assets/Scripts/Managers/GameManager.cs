using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Utilities;

namespace Managers
{

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public float gameSpeed = 1;
    private float _gameSpeed = 1f;
    public TextMeshProUGUI scoreText;
    public bool isGameOver = false;
    public GameObject gameOverScreen;
    public AudioSource gameOverSound;
    public AudioSource scoreSound;
    
    private void Start()
    {
        _gameSpeed = gameSpeed;
        GameBounds.UpdateBounds(Camera.main);
        Debug.Log($"Game Bounds: Left: {GameBounds.Left}, Right: {GameBounds.Right}, Top: {GameBounds.Top}, Bottom: {GameBounds.Bottom}");
    }

    [ContextMenu("Add Score")]
    public void AddScore(int toAdd = 1)
    {
        score += toAdd;
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned in the GameManager!");
        }
        if (scoreSound != null)
        {
            scoreSound.Play();
        }
        else
        {
            Debug.LogWarning("Score Sound is not assigned in the GameManager!");
        }
    }

    public void RestartGame()
    {
        if (!isGameOver) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameOver = false;
        gameSpeed = _gameSpeed;
        gameOverScreen.SetActive(isGameOver);
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        gameSpeed /= 2;
        gameOverScreen.SetActive(isGameOver);
        if (gameOverSound != null)
        {
            gameOverSound.Play();
        }
        else
        {
            Debug.LogWarning("Game Over Sound is not assigned in the GameManager!");
        }
    }
    
}

}