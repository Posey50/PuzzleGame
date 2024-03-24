using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    // Singleton
    private static HUDManager _instance = null;
    public static HUDManager Instance => _instance;

    #region PauseButtons
    [Header("Pause")]
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
    /// Button to retry the lvl when game is pause.
    /// </summary>
    [SerializeField]
    private Button _pauseRetryButton;

    /// <summary>
    /// Button to go back to the main menu when game is pause.
    /// </summary>
    [SerializeField]
    private Button _pauseMenuButton;
    #endregion

    #region ResultsButtons
    [Space]
    [Header("Results")]
    /// <summary>
    /// Button to go to the next lvl.
    /// </summary>
    [SerializeField]
    private Button _nextLvlButton;

    /// <summary>
    /// Button to retry the lvl when results are showed.
    /// </summary>
    [SerializeField]
    private Button _resultsRetryButton;

    /// <summary>
    /// Button to go back to the main menu when results are showed.
    /// </summary>
    [SerializeField]
    private Button _resultsMenuButton;
    #endregion

    #region LooseButtons
    [Space]
    [Header("Loose")]
    /// <summary>
    /// Button to retry the lvl when game is lost.
    /// </summary>
    [SerializeField]
    private Button _looseRetryButton;

    /// <summary>
    /// Button to go back to the main menu when game is lost.
    /// </summary>
    [SerializeField]
    private Button _looseMenuButton;
    #endregion

    /// <summary>
    /// Animator of the HUD.
    /// </summary>
    private Animator _animator;

    [Space]
    /// <summary>
    /// Script which manages results.
    /// </summary>
    [SerializeField]
    private Results _results;

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
    }

    private void Start()
    {
        _pauseButton.onClick.AddListener(PauseGame);
        _resumeButton.onClick.AddListener(ResumeGame);
        _pauseRetryButton.onClick.AddListener(PauseRetry);
        _pauseMenuButton.onClick.AddListener(PauseGoBackToMenu);

        LvlArrival.Instance.EndReached += ShowResults;
        if (_nextLvlButton != null)
        {
            _nextLvlButton.onClick.AddListener(GoToNextLvl);
        }
        _resultsRetryButton.onClick.AddListener(ResultsRetry);
        _resultsMenuButton.onClick.AddListener(ResultsGoBackToMenu);

        LvlManager.Instance.GameLost += ShowLooseScreen;
        _looseRetryButton.onClick.AddListener(LooseRetry);
        _looseMenuButton.onClick.AddListener(LooseGoBackToMenu);
    }

    /// <summary>
    /// Called when the countdown is ended.
    /// </summary>
    private void StartGame()
    {
        CountdownEnded?.Invoke();
    }

    #region PauseMethods
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
    /// Called to retry when game is pause.
    /// </summary>
    private void PauseRetry()
    {
        Time.timeScale = 1f;
        _animator.Play("PauseRetry");
    }

    /// <summary>
    /// Called to go back to the main menu when game is pause.
    /// </summary>
    private void PauseGoBackToMenu()
    {
        _animator.Play("PauseGoBackToMenu");
    }
    #endregion

    #region ResultsMethods
    /// <summary>
    /// Called to show results.
    /// </summary>
    private void ShowResults()
    {
        _animator.Play("Results");
    }

    /// <summary>
    /// Called to launch the stars display.
    /// </summary>
    private void LaunchStarsDisplay()
    {
        _results.ShowStars();
    }

    /// <summary>
    /// Called to go to the next lvl.
    /// </summary>
    private void GoToNextLvl()
    {
        _animator.Play("GoToNextLvl");
    }

    /// <summary>
    /// Called to change scene to next lvl.
    /// </summary>
    private void LoadNextLvl()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Called to retry when results are showed.
    /// </summary>
    private void ResultsRetry()
    {
        _animator.Play("ResultsRetry");
    }

    /// <summary>
    /// Called to go back to the main menu when results are showed.
    /// </summary>
    private void ResultsGoBackToMenu()
    {
        _animator.Play("ResultsGoBackToMenu");
    }
    #endregion

    #region ResultsMethods
    /// <summary>
    /// Called to show the loose screen.
    /// </summary>
    private void ShowLooseScreen()
    {
        _animator.Play("Loose");
    }

    /// <summary>
    /// Called to retry when the game is lost.
    /// </summary>
    private void LooseRetry()
    {
        _animator.Play("LooseRetry");
    }

    /// <summary>
    /// Called to go back to the main menu when the game is lost.
    /// </summary>
    private void LooseGoBackToMenu()
    {
        _animator.Play("LooseGoBackToMenu");
    }
    #endregion

    /// <summary>
    /// Called to change scene to main menu.
    /// </summary>
    private void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Called to reload the current lvl.
    /// </summary>
    private void ReloadCurrentLvl()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}