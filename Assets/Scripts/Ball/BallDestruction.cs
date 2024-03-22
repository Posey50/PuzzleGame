using UnityEngine;

public class BallDestruction : MonoBehaviour
{
    /// <summary>
    /// Event to indicate that the ball is destroyed.
    /// </summary>
    public delegate void BallDelegate();
    public event BallDelegate BallIsDestroyed;

    /// <summary>
    /// A value indicating that the ball has already been destroyed.
    /// </summary>
    private bool _isAlreadyDestroyed;

    private void Start()
    {
        BallIsDestroyed += LvlManager.Instance.RespawnABall;
    }

    /// <summary>
    /// Called to destroy the ball.
    /// </summary>
    public void DestroySelf()
    {
        if (!_isAlreadyDestroyed)
        {
            _isAlreadyDestroyed = true;
            BallIsDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
