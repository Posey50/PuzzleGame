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
        LvlManager.Instance.NeedABall += SpawnABall;
        SpawnABall();
    }

    public void SpawnABall()
    {
        if (_ball != null)
        {
            GameObject newBall = Instantiate(_ball, transform.position, _ball.transform.rotation);
            newBall.GetComponent<BallDestruction>().BallIsDestroyed += LvlManager.Instance.RespawnABall;
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
