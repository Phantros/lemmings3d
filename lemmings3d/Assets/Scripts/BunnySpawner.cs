using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BunnySpawner : MonoBehaviour
{

    public GameObject bunnyOriginal;
    public GameObject bunnyContainer;

    public int maxBunnies;
    public int maxCountdown;

    private int amountOfBunnies;
    private int countdown;

    private void Start()
    {
        countdown = 0;
    }

    private void Update()
    {
        countdown++;

        if (countdown >= maxCountdown)
        {
            InstantiateBunny();
        }
    }

    private void InstantiateBunny()
    {
        if (amountOfBunnies >= maxBunnies)
        {
            return;
        }

        else
        {
            GameObject BunnyClone = Instantiate(bunnyOriginal, this.transform.position, Quaternion.identity);
            BunnyClone.transform.parent = bunnyContainer.transform;
            BunnyClone.name = "Bunny_" + (amountOfBunnies + 1);
            amountOfBunnies++;
            countdown = 0;
        }
    }
}
