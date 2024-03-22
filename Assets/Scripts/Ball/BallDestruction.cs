using UnityEngine;

public class BallDestruction : MonoBehaviour
{
    /// <summary>
    /// Event to indicate that the ball is destroyed.
    /// </summary>
    public delegate void BallDelegate();
    public event BallDelegate BallIsDestroyed;

    /// <summary>
    /// Called to destroy the ball.
    /// </summary>
    public void DestroySelf()
    {
        BallIsDestroyed?.Invoke();
        Destroy(gameObject);
    }
}
