using UnityEngine;

public class Boost : MonoBehaviour
{
    /// <summary>
    /// Force applied on the ball.
    /// </summary>
    [SerializeField]
    private float _force;

    /// <summary>
    /// Current direction towards which the ball is accelerated.
    /// </summary>
    private Vector3 _currentDirection;

    /// <summary>
    /// Visualisations of the boost.
    /// </summary>
    [SerializeField]
    private GameObject _visualBoost, _reverseVisualBoost;

    private void Start()
    {
        _currentDirection = transform.right;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.GetComponent<Rigidbody>().AddForce(_currentDirection * _force, ForceMode.Acceleration);
        }
    }

    /// <summary>
    /// Called to change the direction of the boost.
    /// </summary>
    public void ChangeDirection()
    {
        _currentDirection = -_currentDirection;

        if (_currentDirection.x < 0f)
        {
            _reverseVisualBoost.SetActive(false);
            _visualBoost.SetActive(true);
        }
        else
        {
            _visualBoost.SetActive(false);
            _reverseVisualBoost.SetActive(true);
        }
    }
}
