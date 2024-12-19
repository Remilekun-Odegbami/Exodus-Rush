using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFX;


    private void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        CollectableCounter.coinCount++;
        this.gameObject.SetActive(false);
    }
}
