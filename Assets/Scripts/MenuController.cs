using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;

    [SerializeField] private GameObject[] _deactivatedObjects;

    public void Pause()
    {
        _pauseScreen.SetActive(true);

        Time.timeScale = 0f;

        foreach (GameObject deactivatedObject in _deactivatedObjects)
        {
            deactivatedObject.SetActive(false);
        }
    }

    public void Continue()
    {
        _pauseScreen.SetActive(false);

        Time.timeScale = 1f;
        
        foreach (GameObject deactivatedObject in _deactivatedObjects)
        {
            deactivatedObject.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    
}
