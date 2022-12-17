using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float timer;
    private int tempLevel;
    private int waveNum;

    [SerializeField]
    private float waveInterval = 10;

    [SerializeField]
    private int[] tempChangeTimings;

    [SerializeField]
    private float freezeMultiplier;
    [SerializeField]
    private float freezeDamageInterval;
    private float freezeTimer;


    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        freezeTimer = 0;
        timer = 0;
        tempLevel = 0;
        waveNum = 1;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //enemies
        if (timer >= waveNum * waveInterval)
        {
            spawnWave();
        }

        //temperature decrease
        if (tempLevel < tempChangeTimings.Length)
        {
            if (timer >= tempChangeTimings[tempLevel])
            {
                tempDecrease();
            }
        }


        //freeze (or thaw) the player
        playerController.ChangeFreeze((tempLevel - playerController.GetHeat()) * Time.deltaTime * freezeMultiplier);

        //check freeze damage after freezing player
        if(playerController.GetFreeze() >= 100)
        {
            freezeTimer += Time.deltaTime;
            if (freezeTimer >= freezeDamageInterval)
            {
                playerController.ChangeHealth(-1);
                freezeTimer = 0;
            }
        }
    }

    private void tempDecrease()
    {
        //TODO: send out a signal that the temperature decreased
        tempLevel += 1; //note - templevel increasing means it's colder now
        Debug.Log("it's colder now!");
    }

    public float getTime()
    {
        return timer;
    }

    public int getTemp()
    {
        return tempLevel;
    }

    public void spawnWave()
    {
        Debug.Log("this would be a wave spawn");
        waveNum += 1;
    }
}
