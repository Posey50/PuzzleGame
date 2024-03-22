using UnityEngine;

public class LvlManager : MonoBehaviour
{
    // Singleton
    private static LvlManager _instance = null;
    public static LvlManager Instance => _instance;

    [Header("Third star timer")]
    /// <summary>
    /// Timing not to exceed to have the third star.
    /// </summary>
    [SerializeField]
    private int _minutes;
    [SerializeField]
    private int seconds;

    [Header("Lvl datas")]
    /// <summary>
    /// Number of life to finish the lvl.
    /// </summary>
    [SerializeField]
    private int _nbrOfLife;

    /// <summary>
    /// Current number of life.
    /// </summary>
    private int _currentNbrOfLife;

    /// <summary>
    /// Event to indicate lvl state.
    /// </summary>
    public delegate void LvlDelegate();
    public event LvlDelegate NeedABall;

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
        _currentNbrOfLife = _nbrOfLife;
    }

    /// <summary>
    /// Called to check if it's possible to respawn a ball.
    /// </summary>
    public void RespawnABall()
    {
        if (_currentNbrOfLife - 1 >= 0)
        {
            _currentNbrOfLife--;
            NeedABall?.Invoke();
        }
        else
        {
            Debug.Log("GameOver");
        }
    }
}
