using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    /// <summary>
    /// Ball to spawn.
    /// </summary>
    [SerializeField]
    private GameObject _ball;

    private void Start()
    {
        HUDManager.Instance.CountdownEnded += SpawnABall;
        LvlManager.Instance.NeedABall += SpawnABall;
    }

    public void SpawnABall()
    {
        if (_ball != null)
        {
            Instantiate(_ball, transform.position, _ball.transform.rotation);
        }
    }

    #region Preview
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (_ball != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, new Vector3(1f, 1f, 1f));
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireMesh(_ball.GetComponent<MeshFilter>().sharedMesh, 0, transform.position, _ball.transform.rotation, _ball.transform.localScale);
        }
        else
        {
            Debug.LogError("There is no ball attached to " + this.gameObject.name);
        }
    }
#endif
    #endregion
}
