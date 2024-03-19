using UnityEngine;

public class ObjectAffectedByTime : MonoBehaviour
{
    /// <summary>
    /// Animator of the object.
    /// </summary>
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();

        TimeManager.Instance.TimeChanged += SetSpeed;
    }

    /// <summary>
    /// Called when time scale is changed to update the speed of the animation.
    /// </summary>
    /// <param name="newSpeed"> New speed to set. </param>
    private void SetSpeed(float newSpeed)
    {
        _animator.SetFloat("TimeScale", newSpeed);
    }
}
