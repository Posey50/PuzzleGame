using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BlurManager : MonoBehaviour
{
    // Singleton
    private static BlurManager _instance = null;
    public static BlurManager Instance => _instance;

    /// <summary>
    /// Blur on screen.
    /// </summary>
    private DepthOfField _blur;

    /// <summary>
    /// Intensity of the blur.
    /// </summary>
    [SerializeField, Range(1f, 25f)]
    private int _blurIntensity;

    private void Awake()
    {
        // Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        if (GetComponent<Volume>().profile.TryGet<DepthOfField>(out DepthOfField depthOfField))
        {
            _blur = depthOfField;
        }
    }

    private void Update()
    {
        _blur.focalLength.value = _blurIntensity;
    }
}
