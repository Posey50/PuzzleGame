using UnityEngine;

public class Translation : MonoBehaviour
{
    /// <summary>
    /// Type of the movement.
    /// </summary>
    [SerializeField]
    private MovementType _movementType;

    /// <summary>
    /// Axe on wich the translation is.
    /// </summary>
    [SerializeField]
    private Axe _axe;

    /// <summary>
    /// Object which will be moved.
    /// </summary>
    [SerializeField]
    private GameObject _objectToMove;

    /// <summary>
    /// Range of the ping pong.
    /// </summary>
    [SerializeField, Range(1, 10)]
    private int _range;

    /// <summary>
    /// Speed of the animation.
    /// </summary>
    [SerializeField]
    private float _speed;

    /// <summary>
    /// Animator of the object.
    /// </summary>
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        if (_movementType != MovementType.None)
        {
            _animator.Play(_movementType.ToString() + (_range - 1).ToString() + _axe.ToString());
        }
        else
        {
            _animator.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        _animator.speed = _speed / _range;
    }

    #region Preview
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (_objectToMove != null)
        {
            switch (_movementType.ToString())
            {
                case "PingPong":
                    switch (_axe.ToString())
                    {
                        case "X":
                            Gizmos.color = Color.green;
                            Gizmos.DrawWireMesh(_objectToMove.GetComponent<MeshFilter>().sharedMesh, 0, _objectToMove.transform.position + transform.right * _range, _objectToMove.transform.rotation, _objectToMove.transform.localScale);
                            Gizmos.color = Color.red;
                            Gizmos.DrawWireMesh(_objectToMove.GetComponent<MeshFilter>().sharedMesh, 0, _objectToMove.transform.position - transform.right * _range, _objectToMove.transform.rotation, _objectToMove.transform.localScale);
                            break;
                        case "Y":
                            Gizmos.color = Color.green;
                            Gizmos.DrawWireMesh(_objectToMove.GetComponent<MeshFilter>().sharedMesh, 0, _objectToMove.transform.position + transform.up * _range, _objectToMove.transform.rotation, _objectToMove.transform.localScale);
                            Gizmos.color = Color.red;
                            Gizmos.DrawWireMesh(_objectToMove.GetComponent<MeshFilter>().sharedMesh, 0, _objectToMove.transform.position - transform.up * _range, _objectToMove.transform.rotation, _objectToMove.transform.localScale);
                            break;
                        case "Z":
                            Gizmos.color = Color.green;
                            Gizmos.DrawWireMesh(_objectToMove.GetComponent<MeshFilter>().sharedMesh, 0, _objectToMove.transform.position + transform.forward * _range, _objectToMove.transform.rotation, _objectToMove.transform.localScale);
                            Gizmos.color = Color.red;
                            Gizmos.DrawWireMesh(_objectToMove.GetComponent<MeshFilter>().sharedMesh, 0, _objectToMove.transform.position - transform.forward * _range, _objectToMove.transform.rotation, _objectToMove.transform.localScale);
                            break;
                        default:
                            break;
                    }
                    break;
                case "Piston":
                    switch (_axe.ToString())
                    {
                        case "X":
                            Gizmos.color = Color.green;
                            Gizmos.DrawWireMesh(_objectToMove.GetComponent<MeshFilter>().sharedMesh, 0, _objectToMove.transform.position + transform.right * _range, _objectToMove.transform.rotation, _objectToMove.transform.localScale);
                            break;
                        case "Y":
                            Gizmos.color = Color.green;
                            Gizmos.DrawWireMesh(_objectToMove.GetComponent<MeshFilter>().sharedMesh, 0, _objectToMove.transform.position + transform.up * _range, _objectToMove.transform.rotation, _objectToMove.transform.localScale);
                            break;
                        case "Z":
                            Gizmos.color = Color.green;
                            Gizmos.DrawWireMesh(_objectToMove.GetComponent<MeshFilter>().sharedMesh, 0, _objectToMove.transform.position + transform.forward * _range, _objectToMove.transform.rotation, _objectToMove.transform.localScale);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            Debug.LogError("There is no object to move in " + this.gameObject.name);
        }
    }
#endif
    #endregion
}
