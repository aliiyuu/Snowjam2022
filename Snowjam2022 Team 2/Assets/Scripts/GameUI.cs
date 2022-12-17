using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Handles loading/transitioning scenes, along with Main Menu operations
/// </summary>
public class GameUI : MonoBehaviour
{
    enum Screen
    {
        Title,
        Play,
        Help,
        Credits,
        Settings,
        Inventory,
        Quit
    }

    // Variables
    [SerializeField] private string gameplaySceneName;
    [SerializeField] private GameObject fadeTransition;
    private Animator fadeAnimator;
    [SerializeField] private float fadeSpeed = 1f;
    private Screen selectedMenu = Screen.Title;
    private Screen previousMenu;
    [SerializeField] GameObject[] menus;
    private GameObject helpMenu;
    private GameObject creditsMenu;
    private GameObject settingsMenu;
    private GameObject inventory;

    [SerializeField] private GameObject healthMask;
    [SerializeField] private float[] healthMaskRange = new float[2];
    [SerializeField] private GameObject temperatureMask;
    [SerializeField] private float[] temperatureMaskRange = new float[2];
    [SerializeField] private GameObject timeMask;
    [SerializeField] private float[] timeMaskRange = new float[2];

    void Start()
    {
        fadeAnimator = fadeTransition.GetComponent<Animator>();
        StartCoroutine(FadeButtonPressed("in"));

        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(false);
            switch(menus[i].name)
            {
                case "Help":
                    helpMenu = menus[i];
                    break;
                case "Credits":
                    creditsMenu = menus[i];
                    break;
                case "Settings":
                    settingsMenu = menus[i];
                    break;
                case "Inventory":
                    inventory = menus[i];
                    break;
            }
        }
    }

    void Update()
    {
        fadeAnimator.speed = fadeSpeed;
    }

    public void SetHealthUI(float percent)
    {
        healthMask.GetComponent<RectMask2D>().padding = new Vector4(healthMask.GetComponent<RectMask2D>().padding.x, healthMask.GetComponent<RectMask2D>().padding.y, percent / 100f * (healthMaskRange[1] - healthMaskRange[0]) + healthMaskRange[0], healthMask.GetComponent<RectMask2D>().padding.w);
    }

    public void SetTemperatureUI(float percent)
    {
        temperatureMask.GetComponent<RectMask2D>().padding = new Vector4(temperatureMask.GetComponent<RectMask2D>().padding.x, temperatureMask.GetComponent<RectMask2D>().padding.y, percent / 100f * (temperatureMaskRange[1] - temperatureMaskRange[0]) + temperatureMaskRange[0], temperatureMask.GetComponent<RectMask2D>().padding.w);
    }

    public void SetTimeUI(float percent)
    {
        timeMask.GetComponent<RectMask2D>().padding = new Vector4(timeMask.GetComponent<RectMask2D>().padding.x, timeMask.GetComponent<RectMask2D>().padding.y, percent / 100f * (timeMaskRange[1] - timeMaskRange[0]) + timeMaskRange[0], timeMask.GetComponent<RectMask2D>().padding.w);
    }

    public void Title()
    {
        previousMenu = selectedMenu;
        selectedMenu = Screen.Title;
        StartCoroutine(FadeButtonPressed("both"));
    }

    public void Play()
    {
        previousMenu = selectedMenu;
        selectedMenu = Screen.Play;
        StartCoroutine(FadeButtonPressed("both"));
    }

    public void Help()
    {
        previousMenu = selectedMenu;
        selectedMenu = Screen.Help;
        StartCoroutine(FadeButtonPressed("both"));
    }
    public void Credits()
    {
        previousMenu = selectedMenu;
        selectedMenu = Screen.Credits;
        StartCoroutine(FadeButtonPressed("both"));
    }
    public void Settings()
    {
        previousMenu = selectedMenu;
        selectedMenu = Screen.Settings;
        StartCoroutine(FadeButtonPressed("both"));
    }
    public void Quit()
    {
        previousMenu = selectedMenu;
        selectedMenu = Screen.Quit;
        StartCoroutine(FadeButtonPressed("both"));
    }

    public void Back() // Go back to the Title or Play screen from the UI
    {
        selectedMenu = previousMenu;
        StartCoroutine(FadeButtonPressed("both"));
    }

    IEnumerator FadeButtonPressed(string whichFade)
    {
        fadeTransition.SetActive(true);

        if (whichFade == "out" || whichFade == "both")
        {
            fadeAnimator.Play("FadeOut");
            yield return new WaitForSeconds(1f / fadeSpeed);

            switch (selectedMenu)
            {
                case Screen.Title:
                    // Close UI Interfaces
                    for (int i = 0; i < menus.Length; i++)
                    {
                        menus[i].SetActive(false);
                    }
                    break;
                case Screen.Play:
                    if (previousMenu == Screen.Title)
                    {
                        SceneManager.LoadScene("Main");
                    }
                    else
                    {
                        // Close UI Interfaces
                        for (int i = 0; i < menus.Length; i++)
                        {
                            menus[i].SetActive(false);
                        }
                    }
                    break;
                case Screen.Help:
                    helpMenu.SetActive(true);
                    break;
                case Screen.Credits:
                    creditsMenu.SetActive(true);
                    break;
                case Screen.Settings:
                    settingsMenu.SetActive(true);
                    break;
                case Screen.Inventory:
                    inventory.SetActive(true);
                    break;
                case Screen.Quit:
                    Application.Quit();
                    break;
            }
        }
        if (whichFade == "in" || whichFade == "both")
        {
            fadeAnimator.Play("FadeIn");
            yield return new WaitForSeconds(1f / fadeSpeed);
        }

        fadeTransition.SetActive(false);
    }
}