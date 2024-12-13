using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentDestroyer : MonoBehaviour
{
    public string parentName;
    void Start()
    {
        // parent name is now whatever the object is called
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(150);
        if (this.CompareTag("Segment")) 
        {
            Destroy(gameObject);
        }
    }
}
