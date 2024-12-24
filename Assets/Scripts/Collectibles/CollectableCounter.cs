using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCounter : MonoBehaviour
{
    public static int coinCount = 0;
    public static int gemCount = 0;
    public static int enemyCount = 0;
    [SerializeField] public GameObject enemyDisplay;
    [SerializeField] public GameObject coinDisplay;
    [SerializeField] public GameObject gemDisplay;
    [SerializeField] GameObject coinEndDisplay;
    [SerializeField] GameObject enemyEndDisplay;

    private void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "" + coinCount;
      //  gemDisplay.GetComponent<TMPro.TMP_Text>().text = "" + gemCount;
        enemyDisplay.GetComponent<TMPro.TMP_Text>().text = "" + enemyCount;
        coinEndDisplay.GetComponent<TMPro.TMP_Text>().text = "" + coinCount;
        enemyEndDisplay.GetComponent<TMPro.TMP_Text>().text = "" + enemyCount;
    }

}
