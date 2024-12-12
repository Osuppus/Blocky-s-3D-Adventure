using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager: MonoBehaviour
{
    public static CoinManager instance; 
    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;

    public int coinsNeededForAbility = 10;

    public bool canShoot = false;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "POINTS: " + coinCount;

    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        CheckAbilityUnlock();
    }

    void CheckAbilityUnlock()
    {
        if (coinCount >= coinsNeededForAbility)
        {
            canShoot = true;
        }
    }







}