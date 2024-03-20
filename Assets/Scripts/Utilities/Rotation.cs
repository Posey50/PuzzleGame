using UnityEngine;

public class Rotation : MonoBehaviour
{
    /// <summary>
    /// Speed of the rotation.
    /// </summary>
    [SerializeField]
    private float _rotationSpeed;

    /// <summary>
    /// Animator of the object.
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// Axe on wich the rotation is.
    /// </summary>
    [SerializeField]
    private Axe _axe;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = _rotationSpeed;
        _animator.Play("Rotation" + _axe.ToString());
    }

    private void FixedUpdate()
    {
        _animator.speed = _rotationSpeed;
    }
}

public enum Axe
{
    X,
    Y, 
    Z
}
