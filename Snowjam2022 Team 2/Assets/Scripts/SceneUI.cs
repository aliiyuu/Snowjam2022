using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles loading/transitioning scenes, along with Main Menu operations
/// </summary>
public class SceneUI : MonoBehaviour
{
    // Variables
    [SerializeField] private string gameplaySceneName;
    [SerializeField] private GameObject fadeTransition;

    // Start is called before the first frame update
    void Start()
    {
        fadeTransition.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Switches to the play scene
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene(gameplaySceneName);
    }

    /// <summary>
    /// Shows the Help UI
    /// </summary>
    public void Help()
    {
        Debug.Log("HELP");
    }
    public void Credits()
    {

    }
    public void Settings()
    {
        
    }
    public void Quit()
    {
        StopAllCoroutines();
        Application.Quit();
    }

    /// <summary>
    /// Fade to black for t seconds
    /// </summary>
    private void FadeTransition(float t)
    { 
        fadeTransition.GetComponent<>()
    }
}