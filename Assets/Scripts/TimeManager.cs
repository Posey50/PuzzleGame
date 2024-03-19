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
    private float _timeScale;

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
    /// Interval between every step.
    /// </summary>
    [SerializeField]
    private float _interval;

    /// <summary>
    /// Slider to control the time scale.
    /// </summary>
    private Slider _slider;

    public delegate void TimeDelegate(float health);
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

        _timeScale = 1f;

        SetSlider();
    }

    /// <summary>
    /// Called to set the slider by default;
    /// </summary>
    private void SetSlider()
    {
        _slider.value = _timeScale;
        _slider.minValue = _minRange;
        _slider.maxValue = _maxRange;
        _slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    /// <summary>
    /// Called when the slider moves.
    /// </summary>
    /// <param name="value"> The new value of the slider. </param>
    private void OnSliderValueChanged(float value)
    {
        _timeScale = _slider.value;
        TimeChanged?.Invoke(_timeScale);
        Debug.Log(_timeScale);
    }
}
