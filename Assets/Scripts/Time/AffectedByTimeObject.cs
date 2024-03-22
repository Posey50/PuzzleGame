using UnityEngine;

public class ObjectAffectedByTime : MonoBehaviour
{
    /// <summary>
    /// Animator of the object.
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// Object which will be affected.
    /// </summary>
    [field: SerializeField]
    public MeshRenderer ObjectAffected { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Called when time scale is changed to update the speed of the animation.
    /// </summary>
    /// <param name="newSpeed"> New speed to set. </param>
    public void SetSpeed(float newSpeed)
    {
        _animator.SetFloat("TimeScale", newSpeed);
    }
}
