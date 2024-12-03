using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public static int coinCount = 0;
    public static int gemCount = 0;
    [SerializeField] GameObject coinDisplay;
    [SerializeField] GameObject gemDisplay;

    private void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinCount;
        gemDisplay.GetComponent<TMPro.TMP_Text>().text = "GEMS: " + gemCount;
    }

}
