using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCovered : MonoBehaviour
{
    public GameObject distanceDisplay;
    public int distanceRan;
    public bool addingDistance = false;
    public float disDisplay = 0.35f;

    void Update()
    {
        if(addingDistance == false)
        {
            addingDistance = true;
            StartCoroutine(AddingDistance());
        }
    }

    IEnumerator AddingDistance()
    {
        distanceRan++;
        distanceDisplay.GetComponent<TMPro.TMP_Text>().text = "" + distanceRan;
        yield return new WaitForSeconds(disDisplay); 
        addingDistance = false;
    }
}
