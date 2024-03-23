using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour
{
    // Singleton
    private static HUDManager _instance = null;
    public static HUDManager Instance => _instance;

    /// <summary>
    /// Button to pause the game.
    /// </summary>
    [SerializeField]
    private Button _pauseButton;

    /// <summary>
    /// Button to resume the game.
    /// </summary>
    [SerializeField]
    private Button _resumeButton;

    /// <summary>
    /// Button to go back to the main menu.
    /// </summary>
    [SerializeField]
    private Button _menuButton;

    /// <summary>
    /// Animator of the HUD.
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// Event to indicate that the countdown is ended.
    /// </summary>
    public delegate void HUDDelegate();
    public event HUDDelegate CountdownEnded;

    private void Awake()
    {
        // Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        _animator = GetComponent<Animator>();
        _pauseButton.onClick.AddListener(PauseGame);
        _resumeButton.onClick.AddListener(ResumeGame);
        _menuButton.onClick.AddListener(GoBackToMenu);
    }

    /// <summary>
    /// Called when the countdown is ended.
    /// </summary>
    public void StartGame()
    {
        CountdownEnded?.Invoke();
    }

    /// <summary>
    /// Called to pause the game.
    /// </summary>
    private void PauseGame()
    {
        Time.timeScale = 0f;
        _animator.Play("Pause");
    }

    /// <summary>
    /// Called to resume the game.
    /// </summary>
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        _animator.Play("Resume");
    }

    /// <summary>
    /// Called to go back to the main menu.
    /// </summary>
    private void GoBackToMenu()
    {
        _animator.Play("GoBackToMenu");
    }

    /// <summary>
    /// Called to change scene to main menu.
    /// </summary>
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
