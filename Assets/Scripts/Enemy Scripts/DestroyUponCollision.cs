using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUponCollision : MonoBehaviour
{
    [SerializeField] AudioSource enemyFX;
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Enemy"))
        {
            enemyFX.Play();
        int enemy = CollectableCounter.enemyCount++;
            Destroy(this.gameObject);
        }
    }
}
