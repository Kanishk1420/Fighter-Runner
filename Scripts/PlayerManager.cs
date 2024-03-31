using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public AudioSource backgroundMusic; // Add this line

    private void Awake()
    {
        isGameOver = false;

        // Increase the capacity to 500 active tweens and 100 pooled tweens
        DOTween.SetTweensCapacity(500, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            ShowGameOverScreen();
            backgroundMusic.Stop(); // Stop the music
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        backgroundMusic.Play(); // Start the music
    }

    private void ShowGameOverScreen()
    {
        if (gameOverScreen != null) // Check if gameOverScreen is not null
        {
            gameOverScreen.SetActive(true);
            gameOverScreen.transform.DOLocalMoveX(0, 0.6f); // Move the game over screen from the side
        }
    }
}
