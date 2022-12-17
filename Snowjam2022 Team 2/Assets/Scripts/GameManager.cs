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


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        tempLevel = 0;
        waveNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waveNum * waveInterval)
        {
            spawnWave();
            waveNum += 1;
        }
        if (tempLevel < tempChangeTimings.Length)
        {
            if (timer >= tempChangeTimings[tempLevel])
            {
                tempDecrease();
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
    }
}
