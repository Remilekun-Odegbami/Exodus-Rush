using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditContent : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    // Start is called before the first frame update
    void Start()
    {

        if (scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition = -200f;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
