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
        _animator.Play("Rotation" + _axe.ToString());
    }

    private void FixedUpdate()
    {
        _animator.speed = _rotationSpeed;
    }

    #region Preview
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        switch (_axe.ToString())
        {
            case "X":
                Gizmos.color = Color.red;
                Gizmos.DrawRay(transform.position, transform.right * 2f);
                Gizmos.DrawRay(transform.position, -transform.right * 2f);
                break;
            case "Y":
                Gizmos.color = Color.green;
                Gizmos.DrawRay(transform.position, transform.up * 2f);
                Gizmos.DrawRay(transform.position, -transform.up * 2f);
                break;
            case "Z":
                Gizmos.color = Color.blue;
                Gizmos.DrawRay(transform.position, transform.forward * 2f);
                Gizmos.DrawRay(transform.position, -transform.forward * 2f);
                break;
        }
    }
#endif
    #endregion
}
