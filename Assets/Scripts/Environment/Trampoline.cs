using UnityEngine;

public class Trampoline : MonoBehaviour
{
    /// <summary>
    /// Animator of the trampoline.
    /// </summary>
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _animator.Play("TrampolineBounce");
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
