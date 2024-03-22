using UnityEngine;

public class BallDestruction : MonoBehaviour
{
    /// <summary>
    /// Event to indicate that the ball is destroyed.
    /// </summary>
    public delegate void BallDelegate();
    public event BallDelegate BallIsDestroyed;

    public void OnDestroy()
    {
        BallIsDestroyed?.Invoke();
    }
}
