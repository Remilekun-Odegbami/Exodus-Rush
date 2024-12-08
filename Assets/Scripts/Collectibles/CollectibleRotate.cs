using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleRotate : MonoBehaviour
{

    [SerializeField] int rotateSpeed = 1;

    private void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

}
