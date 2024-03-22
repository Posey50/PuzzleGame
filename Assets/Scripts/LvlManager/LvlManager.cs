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
    /// Window where results are showed.
    /// </summary>
    [SerializeField]
    private GameObject _resultWindow;

    /// <summary>
    /// Event to indicate lvl state.
    /// </summary>
    public delegate void LvlDelegate();
    public event LvlDelegate NeedABall;

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
        NewNumberOfLifes?.Invoke(CurrentNbrOfLife);
        LvlArrival.Instance.EndReached += GameIsOver;
    }

    /// <summary>
    /// Called to check if it's possible to respawn a ball.
    /// </summary>
    public void RespawnABall()
    {
        if (CurrentNbrOfLife - 1 >= 0)
        {
            CurrentNbrOfLife--;
            NewNumberOfLifes?.Invoke(CurrentNbrOfLife);
            NeedABall?.Invoke();
        }
        else
        {
            GameIsOver();
        }
    }

    /// <summary>
    /// Called when the game is over to show result window.
    /// </summary>
    private void GameIsOver()
    {
        _resultWindow.SetActive(true);
    }
}
