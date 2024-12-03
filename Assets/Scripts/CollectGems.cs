using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGems : MonoBehaviour
{
    [SerializeField] AudioSource gemFX;

    private void OnTriggerEnter(Collider other)
    {
        gemFX.Play();
        CoinCounter.gemCount++;
        this.gameObject.SetActive(false);
    }
}
