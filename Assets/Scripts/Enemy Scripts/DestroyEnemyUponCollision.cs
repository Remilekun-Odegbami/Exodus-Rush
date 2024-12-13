using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyUponCollision : MonoBehaviour
{
    [SerializeField] AudioSource enemyFX;
  //  [SerializeField] GameObject playerAnimation;
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Enemy"))
        {

           // playerAnimation.GetComponent<Animator>().Play("Take 001");
            enemyFX.Play();
        int enemy = CollectableCounter.enemyCount++;
          //  Destroy(this.gameObject);
        }
    }
}
