using UnityEngine; // Imports Unity Engine namespace
using UnityEngine.SceneManagement; // Imports Scene Management namespace
using DG.Tweening;
using System.Threading.Tasks;

public class PauseMenu : MonoBehaviour // Class for handling pause menu
{
    [SerializeField] GameObject pauseMenu; // Reference to the pause menu object
    [SerializeField] RectTransform pausePanelRect,pauseButtonRect;
    [SerializeField] float topPosY, middlePosY;
    [SerializeField] float tweenDuration;
    [SerializeField] CanvasGroup canvasGroup; // Dark Panel canvas group

    public void Pause() // Method to pause the game
    {
        pauseMenu.SetActive(true); // Activates the pause menu
        Time.timeScale = 0; // Pauses the game
        PausePanelIntro();
    }

    public void Home() // Method to go to the home scene
    {
        Debug.Log("Home button clicked"); // Logs button click
        SceneManager.LoadScene("SampleScene"); // Loads the home scene
        Time.timeScale = 1; // Resumes the game time
    }

    public async void Resume() // Method to resume the game
    {
        await PausePanelOutro();
        pauseMenu.SetActive(false); // Deactivates the pause menu
        Time.timeScale = 1; // Resumes the game time
    }

    public void Restart() // Method to restart the current scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the current scene
        Time.timeScale = 1; // Resumes the game time
    }
    void PausePanelIntro()
    {
        canvasGroup.DOFade(1, tweenDuration).SetUpdate(true);
        pausePanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
        pauseButtonRect.DOAnchorPosX(1178, tweenDuration).SetUpdate(true);
    }
    async Task PausePanelOutro()
    {
        canvasGroup.DOFade(0, tweenDuration).SetUpdate(true);
        await pausePanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
        pauseButtonRect.DOAnchorPosX(806.09f, tweenDuration).SetUpdate(true);
    }
}
