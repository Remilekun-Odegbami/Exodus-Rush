using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] Segments;

    [SerializeField] int zPos = 130;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;
    void Update()
    {
        if (!creatingSegment)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, Segments.Length);
        Instantiate(Segments[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 130;
        // turn on the segments after x seconds
        yield return new WaitForSeconds(20);
        creatingSegment = false;

    }
}
