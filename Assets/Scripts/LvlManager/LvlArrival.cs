using UnityEngine;

public class LvlArrival : MonoBehaviour
{
    // Singleton
    private static LvlArrival _instance = null;
    public static LvlArrival Instance => _instance;

    /// <summary>
    /// Events to indicate that the ball has reach the end.
    /// </summary>
    public delegate void ArrivalDelegate();
    public event ArrivalDelegate EndReached;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            EndReached?.Invoke();
        }
    }
}
