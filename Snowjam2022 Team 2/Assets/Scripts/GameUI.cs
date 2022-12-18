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
        Play,
        Title,
        Settings,
        Inventory
    }

    // Variables
    [SerializeField] private string titleSceneName;
    [SerializeField] private GameObject menuTransition;
    [SerializeField] private GameObject fadeTransition;
    private bool currentlyTransitioning = false;
    private Animator fadeAnimator;
    private Animator menuAnimator;
    private Settings settings;

    private Screen selectedMenu = Screen.Play;
    private Screen previousMenu;
    [SerializeField] GameObject[] menus;
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
        menuAnimator = menuTransition.GetComponent<Animator>();
        settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();

        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(false);
            switch(menus[i].name)
            {
                case "Settings":
                    settingsMenu = menus[i];
                    break;
                case "Inventory":
                    inventory = menus[i];
                    break;
            }
        }

        fadeAnimator.Play("FadeOut");
        fadeTransition.SetActive(false);
    }

    void Update()
    {
        fadeAnimator.speed = settings.animationSpeed;

        if (Input.GetKeyDown(KeyCode.Tab) && !currentlyTransitioning)
        {
            Debug.Log("TAB" + selectedMenu);
            if (selectedMenu == Screen.Play) Inventory();
            else if (selectedMenu == Screen.Inventory) Back();
        }
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
        StartCoroutine(Transition());
    }

    public void Settings()
    {
        previousMenu = selectedMenu;
        selectedMenu = Screen.Settings;
        StartCoroutine(Transition());
    }

    public void Inventory()
    {
        previousMenu = selectedMenu;
        selectedMenu = Screen.Inventory;
        StartCoroutine(Transition());
    }

    public void Back() // Go back to the Title or Play screen from the UI
    {
        selectedMenu = Screen.Play;
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        currentlyTransitioning = true;
        switch (selectedMenu)
        {
            case Screen.Title:
                fadeTransition.SetActive(true);
                fadeAnimator.Play("FadeOut");
                yield return new WaitForSeconds(1f / settings.animationSpeed);
                SceneManager.LoadScene(titleSceneName);
                break;

            case Screen.Play:
                // Close UI Interfaces
                menuAnimator.Play("MenuHide");
                yield return new WaitForSeconds(1f / settings.animationSpeed);
                //for (int i = 0; i < menus.Length; i++)
                //{
                //    menus[i].SetActive(false);
                //}
                break;

            case Screen.Settings:
                if (!inventory.activeSelf)
                {
                    settingsMenu.SetActive(true);
                    menuAnimator.Play("MenuShow");
                    yield return new WaitForSeconds(1f / settings.animationSpeed);
                }
                break;

            case Screen.Inventory:
                if (!settingsMenu.activeSelf)
                {
                    inventory.SetActive(true);
                    menuAnimator.Play("MenuShow");
                    yield return new WaitForSeconds(1f / settings.animationSpeed);
                }
                break;

        }
        currentlyTransitioning = false;
    }
}