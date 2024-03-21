using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // Singleton
    private static TimeManager _instance = null;

    public static TimeManager Instance => _instance;

    /// <summary>
    /// Time scale used by the environment.
    /// </summary>
    public float TimeScale {  get; private set; }

    /// <summary>
    /// Minimum of the time scale.
    /// </summary>
    [SerializeField]
    private float _minRange;

    /// <summary>
    /// Maximum of the time scale.
    /// </summary>
    [SerializeField]
    private float _maxRange;

    /// <summary>
    /// Slider to control the time scale.
    /// </summary>
    private Slider _slider;

    /// <summary>
    /// Event to indicate the new time scale to all objects who depend on it.
    /// </summary>
    /// <param name="timeScale"> New time scale. </param>
    public delegate void TimeDelegate(float timeScale);
    public event TimeDelegate TimeChanged;

    private void Awake()
    {
        // Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _slider = GetComponent<Slider>();

        TimeScale = 1f;

        SetSlider();
    }

    /// <summary>
    /// Called to set the slider by default.
    /// </summary>
    private void SetSlider()
    {
        _slider.minValue = _minRange;
        _slider.maxValue = _maxRange;
        _slider.value = TimeScale * 2f;
        _slider.onValueChanged.AddListener(OnSliderValueChanged);
        OnSliderValueChanged(_slider.value);
    }

    /// <summary>
    /// Called when the slider moves.
    /// </summary>
    /// <param name="value"> The new value of the slider. </param>
    private void OnSliderValueChanged(float value)
    {
        TimeScale = _slider.value / 2f;
        TimeChanged?.Invoke(TimeScale);
    }
}
