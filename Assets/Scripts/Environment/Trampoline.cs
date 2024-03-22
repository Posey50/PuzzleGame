using UnityEngine;

public class Trampoline : MonoBehaviour
{
    /// <summary>
    /// Animator of the trampoline.
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// Multiplier applied on the bounce.
    /// </summary>
    [SerializeField, Range(1f, 10f)]
    private float _bounceForce;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _animator.Play("TrampolineBounce");
            collision.gameObject.GetComponent<Rigidbody>().velocity *= _bounceForce;
        }
    }

    /// <summary>
    /// Called to return to idle animation.
    /// </summary>
    public void ReturnToIdle()
    {
        _animator.Play("Idle");
    }
}
