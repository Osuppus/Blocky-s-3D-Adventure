using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManger : MonoBehaviour
{

    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;  

   

    // Update is called once per frame
    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "POINTS" + coinCount; 
    }
}
