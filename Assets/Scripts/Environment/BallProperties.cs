using UnityEngine;

public class BallProperties : MonoBehaviour
{
    /// <summary>
    /// Direction of the ball.
    /// </summary>
    public Vector3 Direction { get; set; }

    /// <summary>
    /// Initial position of the ball.
    /// </summary>
    public Vector3 InitialPosition { get; set; }

    /// <summary>
    /// Mass of the ball.
    /// </summary>
    public float Mass { get; set; }

    /// <summary>
    /// Drag applied on the ball.
    /// </summary>
    public float Drag { get; set; }
}
