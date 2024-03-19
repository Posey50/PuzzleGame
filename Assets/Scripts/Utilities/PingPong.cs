using UnityEngine;

public class PingPong : MonoBehaviour
{
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
        _animator.speed = _speed / _range;
        _animator.Play("PingPong" + (_range - 1).ToString());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireMesh(GetComponent<MeshFilter>().sharedMesh, 0, transform.position + transform.right * _range, transform.rotation, transform.localScale);
        Gizmos.color = Color.green;
        Gizmos.DrawWireMesh(GetComponent<MeshFilter>().sharedMesh, 0, transform.position - transform.right * _range, transform.rotation, transform.localScale);
    }
}
