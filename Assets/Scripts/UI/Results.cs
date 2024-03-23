using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Results : MonoBehaviour
{
    /// <summary>
    /// Stars in the result window.
    /// </summary>
    [SerializeField]
    private List<GameObject> _stars = new ();

    /// <summary>
    /// Number of stars won by the player.
    /// </summary>
    private int _numberOfStars;

    /// <summary>
    /// Called to calculate the number of stars.
    /// </summary>
    private void CalculateResults()
    {
        LvlManager lvlManager = LvlManager.Instance;

        // Checks remaining lifes
        if (lvlManager.CurrentNbrOfLife == lvlManager.NbrOfLife)
        {
            _numberOfStars++;
        }

        List<int> chrono = ChronoManager.Instance.GetChrono();

        // Checks chrono
        if (chrono[0] < lvlManager.Minutes)
        {
            _numberOfStars++;
        }
        else if (chrono[0] == lvlManager.Minutes)
        {
            if (chrono[1] < lvlManager.Seconds)
            {
                _numberOfStars++;
            }
            else if (chrono[1] == lvlManager.Seconds)
            {
                if (chrono[2] == 0)
                {
                    _numberOfStars++;
                }
            }
        }
    }

    /// <summary>
    /// Called to show stars on screen.
    /// </summary>
    public void ShowStars()
    {
        _numberOfStars = 1;
        CalculateResults();
        StartCoroutine(DisplayStars(_numberOfStars));
    }

    /// <summary>
    /// Called to display stars one by one.
    /// </summary>
    /// <param name="nbrOfStars"> Number of stars to display. </param>
    /// <returns></returns>
    private IEnumerator DisplayStars(int nbrOfStars)
    {
        for (int i = 0; i < nbrOfStars; i++)
        {
            _stars[i].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
