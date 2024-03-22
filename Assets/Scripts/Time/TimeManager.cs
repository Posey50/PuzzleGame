using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.ScrollRect;

public class TimeManager : MonoBehaviour
{
    // Singleton
    private static TimeManager _instance = null;

    public static TimeManager Instance => _instance;

    [Header("Slider")]
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
    [SerializeField]
    private Slider _slider;

    /// <summary>
    /// Time scale used by the environment.
    /// </summary>
    private float _timeScale;

    [Header("Level")]
    /// <summary>
    /// Comportement of the time manager.
    /// </summary>
    [SerializeField]
    private TimeType _timeType;

    /// <summary>
    /// Delay before a changes.
    /// </summary>
    [SerializeField]
    private float _delayBetweenChanges;

    /// <summary>
    /// Materials for moving objects.
    /// </summary>
    [SerializeField]
    private Material _goldMaterial, _diamondMaterial;

    /// <summary>
    /// List of all objects affected by time.
    /// </summary>
    [SerializeField]
    private List<ObjectAffectedByTime> _objectsAffectedByTime;

    /// <summary>
    /// List of all objects not affected by time, only necessary in Alternate mode.
    /// </summary>
    [SerializeField]
    private List<ObjectAffectedByTime> _objectsNotAffectedByTime;

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
        _timeScale = 1f;

        switch (_timeType.ToString())
        {
            case "Constant":
                for (int i = 0; i < _objectsAffectedByTime.Count; i++)
                {
                    TimeChanged += _objectsAffectedByTime[i].SetSpeed;
                    _objectsAffectedByTime[i].ObjectAffected.material = _goldMaterial;
                }
                break;
            case "Alternate":
                for (int i = 0; i < _objectsAffectedByTime.Count; i++)
                {
                    TimeChanged += _objectsAffectedByTime[i].SetSpeed;
                    _objectsAffectedByTime[i].ObjectAffected.material = _goldMaterial;
                }
                for (int i = 0; i < _objectsNotAffectedByTime.Count; i++)
                {
                    _objectsNotAffectedByTime[i].GetComponent<ObjectAffectedByTime>().SetSpeed(1f);
                    _objectsNotAffectedByTime[i].ObjectAffected.material = _diamondMaterial;
                }

                StartCoroutine(TimeAlternate());
                break;
        }

        SetSlider();
    }

    /// <summary>
    /// Called to wait before a changes.s
    /// </summary>
    /// <returns></returns>
    private IEnumerator TimeAlternate()
    {
        yield return new WaitForSeconds(_delayBetweenChanges);

        Alternate();
    }

    /// <summary>
    /// Called to change the influence of the time.
    /// </summary>
    private void Alternate()
    {
        // Stocks objects affected by time temporary
        List<ObjectAffectedByTime> temp = new();
        temp.AddRange(_objectsAffectedByTime);
        _objectsAffectedByTime.Clear();

        // Reverses lists
        _objectsAffectedByTime.AddRange(_objectsNotAffectedByTime);
        _objectsNotAffectedByTime.Clear();
        _objectsNotAffectedByTime.AddRange(temp);

        // Changes materials and influences
        for (int i = 0; i < _objectsAffectedByTime.Count; i++)
        {
            TimeChanged += _objectsAffectedByTime[i].SetSpeed;
            _objectsAffectedByTime[i].GetComponent<ObjectAffectedByTime>().SetSpeed(_timeScale);
            _objectsAffectedByTime[i].ObjectAffected.material = _goldMaterial;
        }
        for (int i = 0; i < _objectsNotAffectedByTime.Count; i++)
        {
            TimeChanged -= _objectsNotAffectedByTime[i].SetSpeed;
            _objectsNotAffectedByTime[i].GetComponent<ObjectAffectedByTime>().SetSpeed(1f);
            _objectsNotAffectedByTime[i].ObjectAffected.material = _diamondMaterial;
        }

        StartCoroutine(TimeAlternate());
    }

    /// <summary>
    /// Called to set the slider by default.
    /// </summary>
    private void SetSlider()
    {
        _slider.minValue = _minRange;
        _slider.maxValue = _maxRange;
        _slider.value = _timeScale * 2f;
        _slider.onValueChanged.AddListener(OnSliderValueChanged);
        OnSliderValueChanged(_slider.value);
    }

    /// <summary>
    /// Called when the slider moves.
    /// </summary>
    /// <param name="value"> The new value of the slider. </param>
    private void OnSliderValueChanged(float value)
    {
        _timeScale = _slider.value / 2f;
        TimeChanged?.Invoke(_timeScale);
    }
}
