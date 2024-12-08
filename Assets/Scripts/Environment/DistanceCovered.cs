using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCovered : MonoBehaviour
{
    public GameObject distanceDisplay;
    public int distanceRan;
    public static bool addingDistance = false;
    public static float disDisplay = 0.35f;

    void Update()
    {
        if(addingDistance == false)
        {
            addingDistance = true;
            StartCoroutine(AddingDistance(2f, 3f));
        }
    }

    public IEnumerator AddingDistance(float stopDelay, float restartDelay)
    {
        distanceRan++;
        distanceDisplay.GetComponent<TMPro.TMP_Text>().text = "" + distanceRan + " m";
        yield return new WaitForSeconds(disDisplay); 
        addingDistance = false;
    }
}
