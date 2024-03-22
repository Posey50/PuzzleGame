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

    private void Start()
    {
        CalculateResults();
    }

    /// <summary>
    /// Called to calculate the number of stars.
    /// </summary>
    private void CalculateResults()
    {
        int numberOfStars = 1;

        LvlManager lvlManager = LvlManager.Instance;

        // Checks remaining lifes
        if (lvlManager.CurrentNbrOfLife == lvlManager.NbrOfLife)
        {
            numberOfStars++;
        }

        List<int> chrono = ChronoManager.Instance.GetChrono();

        // Checks chrono
        if (chrono[0] < lvlManager.Minutes)
        {
            numberOfStars++;
        }
        else if (chrono[0] == lvlManager.Minutes)
        {
            if (chrono[1] < lvlManager.Seconds)
            {
                numberOfStars++;
            }
            else if (chrono[1] == lvlManager.Seconds)
            {
                if (chrono[2] == 0)
                {
                    numberOfStars++;
                }
            }
        }

        StartCoroutine(ShowStars(numberOfStars));
    }

    /// <summary>
    /// Called to show stars in results.
    /// </summary>
    /// <param name="nbrOfStars"> Number of stars to show. </param>
    /// <returns></returns>
    private IEnumerator ShowStars(int nbrOfStars)
    {
        for (int i = 0; i < nbrOfStars; i++)
        {
            _stars[i].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
