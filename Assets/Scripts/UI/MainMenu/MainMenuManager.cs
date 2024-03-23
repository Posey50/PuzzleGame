using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Singleton
    private static MainMenuManager _instance = null;

    public static MainMenuManager Instance => _instance;

    /// <summary>
    /// Animator of the menu.
    /// </summary>
    private Animator _animator;

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

        _animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Called to switch to map menu.
    /// </summary>
    public void SwitchToMap()
    {
        _animator.Play("SwitchToMap");
    }

    /// <summary>
    /// Called to switch to main menu.
    /// </summary>
    public void SwitchToMain()
    {
        _animator.Play("SwitchToMain");
    }

    /// <summary>
    /// Called to play a fade out in map menu and get the length of the clip.
    /// </summary>
    /// <returns></returns>
    public float PlayMapFadeOut()
    {
        _animator.Play("MapFadeOut");
        return _animator.GetCurrentAnimatorStateInfo(0).length;
    }

    /// <summary>
    /// Called to play a fade out in main menu and get the length of the clip.
    /// </summary>
    /// <returns></returns>
    public float PlayMainFadeOut()
    {
        _animator.Play("MainFadeOut");
        return _animator.GetCurrentAnimatorStateInfo(0).length;
    }
}
