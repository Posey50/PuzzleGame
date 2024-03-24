using UnityEngine;

public class LvlManager : MonoBehaviour
{
    // Singleton
    private static LvlManager _instance = null;
    public static LvlManager Instance => _instance;

    /// <summary>
    /// Timing not to exceed to have the third star.
    /// </summary>
    [field : SerializeField]
    public int Minutes {  get; private set; }

    [field: SerializeField]
    public int Seconds { get; private set; }

    /// <summary>
    /// Number of life to finish the lvl.
    /// </summary>
    [field : SerializeField]
    public int NbrOfLife { get; private set; }

    /// <summary>
    /// Current number of life.
    /// </summary>
    public int CurrentNbrOfLife { get; private set; }

    /// <summary>
    /// A value indicating that the game is over.
    /// </summary>
    private bool _gameIsOver;

    /// <summary>
    /// Event to indicate lvl state.
    /// </summary>
    public delegate void LvlDelegate();
    public event LvlDelegate NeedABall;
    public event LvlDelegate GameLost;

    /// <summary>
    /// Event to indicate remaining lifes.
    /// </summary>
    public delegate void LifesDelegate(int remainingLifes);
    public event LifesDelegate NewNumberOfLifes;

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
    }

    private void Start()
    {
        CurrentNbrOfLife = NbrOfLife;
        HUDManager.Instance.CountdownEnded += ActualiseUIAtTheEnOfTheCountdown;
        LvlArrival.Instance.EndReached += Win;
    }

    /// <summary>
    /// Called to actualise the number of life when countdown is ended.
    /// </summary>
    private void ActualiseUIAtTheEnOfTheCountdown()
    {
        NewNumberOfLifes?.Invoke(CurrentNbrOfLife);
    }

    /// <summary>
    /// Called to check if it's possible to respawn a ball.
    /// </summary>
    public void RespawnABall()
    {
        if (!_gameIsOver)
        {
            if (CurrentNbrOfLife - 1 >= 0)
            {
                CurrentNbrOfLife--;
                NewNumberOfLifes?.Invoke(CurrentNbrOfLife);
                NeedABall?.Invoke();
            }
            else
            {
                Loose();
            }
        }
    }

    /// <summary>
    /// Called when the game is lost.
    /// </summary>
    private void Win()
    {
        _gameIsOver = true;
    }

    /// <summary>
    /// Called when the game is lost.
    /// </summary>
    private void Loose()
    {
        _gameIsOver = true;
        GameLost?.Invoke();
    }
}
