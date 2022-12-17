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


    private PlayerInteract playerInteract;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        tempLevel = 0;
        waveNum = 1;
        playerInteract = GameObject.Find("Player").GetComponent<PlayerInteract>();
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
        playerInteract.ChangeFreeze((tempLevel - playerInteract.GetHeat()) * Time.deltaTime * freezeMultiplier);

        //check freeze damage after freezing player
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
