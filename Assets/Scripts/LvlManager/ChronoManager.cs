using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoManager : MonoBehaviour
{
    // Singleton
    private static ChronoManager _instance = null;
    public static ChronoManager Instance => _instance;
    //

    /// <summary>
    /// Current number of centiseconds.
    /// </summary>
    private int _nbrOfCentiseconds;

    /// <summary>
    /// Current number of seconds.
    /// </summary>
    private int _nbrOfSeconds;

    /// <summary>
    /// Current number of minutes.
    /// </summary>
    private int _nbrOfMinutes;

    /// <summary>
    /// Coroutine which increase the time.
    /// </summary>
    private Coroutine _increaseChrono;

    /// <summary>
    /// Events to indicate to that there is a new time.
    /// </summary>
    /// <param name="newTime"> New time to declare. </param>
    public delegate void ChronoDelegate(int newTime);
    public event ChronoDelegate NewCentisecond;
    public event ChronoDelegate NewSecond;
    public event ChronoDelegate NewMinute;

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
        //
    }

    private void Start()
    {
        _nbrOfCentiseconds = 0;
        _nbrOfSeconds = 0;
        _nbrOfMinutes = 0;

        _increaseChrono = StartCoroutine(IncreaseChrono());
    }

    /// <summary>
    /// Called to increase the chrono.
    /// </summary>
    /// <returns></returns>
    private IEnumerator IncreaseChrono()
    {
        yield return new WaitForSeconds(0.01f);

        // Increases centiseconds
        // Increases seconds when centiseconds are above 99
        // Increases minutes when seconds are above 59
        if (_nbrOfCentiseconds + 1 == 100 && _nbrOfSeconds + 1 == 60)
        {
            _nbrOfCentiseconds = 0;
            _nbrOfSeconds = 0;
            _nbrOfMinutes++;

            NewCentisecond?.Invoke(_nbrOfCentiseconds);
            NewSecond?.Invoke(_nbrOfSeconds);
            NewMinute?.Invoke(_nbrOfMinutes);
            _increaseChrono = StartCoroutine(IncreaseChrono());
        }
        else if (_nbrOfCentiseconds + 1 == 100 && _nbrOfSeconds < 60)
        {
            _nbrOfCentiseconds = 0;
            _nbrOfSeconds++;

            NewCentisecond?.Invoke(_nbrOfCentiseconds);
            NewSecond?.Invoke(_nbrOfSeconds);
            _increaseChrono = StartCoroutine(IncreaseChrono());
        }
        else
        {
            _nbrOfCentiseconds++;
            NewCentisecond?.Invoke(_nbrOfCentiseconds);
            _increaseChrono = StartCoroutine(IncreaseChrono());
        }
    }

    /// <summary>
    /// Called to stop the chrono.
    /// </summary>
    public void StopChrono()
    {
        StopCoroutine(_increaseChrono);
    }

    /// <summary>
    /// Called to get the chrono.
    /// </summary>
    /// <returns></returns>
    public List<int> GetChrono()
    {
        return new List<int> { _nbrOfMinutes, _nbrOfSeconds, _nbrOfCentiseconds };
    }
}
