using UnityEngine;

public class Canon : MonoBehaviour
{
    [Header("General")]
    /// <summary>
    /// Socket from which ball is launched.
    /// </summary>
    [SerializeField]
    private Transform _ballSocket;

    /// <summary>
    /// Force applied to the ball.
    /// </summary>
    [SerializeField, Range(0f, 100f)]
    private float _force;

    /// <summary>
    /// Ball in the canon.
    /// </summary>
    private GameObject _ballInTheCanon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _ballInTheCanon = other.gameObject;
            SetUpCanon(_ballInTheCanon);
        }
    }

    private void SetUpCanon(GameObject ball)
    {
        if (ball != null)
        {
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.GetComponent<MeshRenderer>().enabled = false;
            ball.GetComponent<Collider>().enabled = false;
            ball.transform.position = _ballSocket.position;
            ball.transform.SetParent(_ballSocket, true);
        }
        else
        {
            Debug.LogError("No ball to load");
        }
    }

    public void Shot()
    {
        if (_ballInTheCanon != null)
        {
            Rigidbody ballRigidbody = _ballInTheCanon.GetComponent<Rigidbody>();
            ballRigidbody.isKinematic = false;
            ballRigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);

            _ballInTheCanon.GetComponent<MeshRenderer>().enabled = true;
            _ballInTheCanon.GetComponent<Collider>().enabled = true;
            _ballInTheCanon.transform.SetParent(null, true);
        }
        else
        {
            Debug.LogError("No ball in the canon");
        }
    }

    #region Preview

    [Header("Preview")]
    /// <summary>
    /// Rigidbody of the ball.
    /// </summary>
    [SerializeField]
    private Rigidbody _ballRigidbody;

    /// <summary>
    /// The time increment used to calculate the trajectory.
    /// </summary>
    private float _increment;

    /// <summary>
    /// The raycast overlap between points in the trajectory, this is a multiplier of the length between points. 2 = twice as long.
    /// </summary>
    private float _rayOverlap;

    /// <summary>
    /// List of the verticles in the line.
    /// </summary>
    private Vector3[] _linePoints = new Vector3[64];

    /// <summary>
    /// Direction of the shot.
    /// </summary>
    private Vector3 _direction;

    /// <summary>
    /// Mass of the ball.
    /// </summary>
    private float _mass;

    /// <summary>
    /// Drag applied on the ball.
    /// </summary>
    private float _drag;

#if UNITY_EDITOR
    /// <summary>
    /// Called to get datas of the ball.
    /// </summary>
    /// <returns></returns>
    private void SetUpDatas()
    {
        if (_ballRigidbody != null)
        {
            _increment = 0.025f;
            _rayOverlap = 1.1f;
            _direction = transform.forward;
            _mass = _ballRigidbody.mass;
            _drag = _ballRigidbody.drag;
        }
        else
        {
            Debug.LogError("Missing ball rigid body in " + this.gameObject.name);
        }
    }

    /// <summary>
    /// Called to show the preview of the trajectory.
    /// </summary>
    public void PredictTrajectory()
    {
        Vector3 velocity = _direction * (_force / _mass);
        Vector3 position = _ballSocket.position;
        Vector3 nextPosition;
        float overlap;

        UpdateLineRender((0, position));

        for (int i = 1; i < _linePoints.Length; i++)
        {
            // Estimate velocity and update next predicted position
            velocity = CalculateNewVelocity(velocity, _drag, _increment);
            nextPosition = position + velocity * _increment;

            // Overlap our rays by small margin to ensure we never miss a surface
            overlap = Vector3.Distance(position, nextPosition) * _rayOverlap;

            // When hitting a surface we want to stop updating our line
            if (Physics.Raycast(position, velocity.normalized, out RaycastHit hit, overlap))
            {
                if (hit.collider.gameObject != this.gameObject)
                {
                    UpdateLineRender((i - 1, hit.point));
                    MaskOtherPoints(i);

                    break;
                }
            }
            position = nextPosition;
            UpdateLineRender((i, position)); //Unneccesary to set count here, but not harmful
        }
    }

    /// <summary>
    /// Called to set line count and an induvidual position at the same time.
    /// </summary>
    /// <param name="count"> Number of points in the line. </param>
    /// <param name="pointPos"> The position of an individual point. </param>
    private void UpdateLineRender((int point, Vector3 pos) pointPos)
    {
        _linePoints[pointPos.point] = pointPos.pos;
    }

    /// <summary>
    /// Called to reset the following points from a given point.
    /// </summary>
    /// <param name="lastIndex"> Point to start. </param>
    private void MaskOtherPoints(int lastIndex)
    {
        if (lastIndex%2 != 0)
        {
            for (int i = lastIndex - 1; i < _linePoints.Length; i++)
            {
                _linePoints[i] = Vector3.zero;
            }
        }
        else
        {
            for (int i = lastIndex; i < _linePoints.Length; i++)
            {
                _linePoints[i] = Vector3.zero;
            }
        }
    }

    /// <summary>
    /// Called to calculate the new velocity.
    /// </summary>
    /// <param name="velocity"> Velocity of the ball. </param>
    /// <param name="drag"> Drag applie on the ball. </param>
    /// <param name="increment"> The time increment used to calculate the trajectory. </param>
    /// <returns></returns>
    private Vector3 CalculateNewVelocity(Vector3 velocity, float drag, float increment)
    {
        velocity += Physics.gravity * increment;
        velocity *= Mathf.Clamp01(1f - drag * increment);
        return velocity;
    }

    private void OnDrawGizmos()
    {
        SetUpDatas();
        PredictTrajectory();
        Gizmos.color = Color.red;
        Gizmos.DrawLineList(_linePoints);
    }
#endif
    #endregion
}
 