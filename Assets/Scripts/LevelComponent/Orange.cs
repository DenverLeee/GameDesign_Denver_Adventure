using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour
{
    public Animator animator;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Touch");
            OrangeUI.currentOrangeNumber += 1;
            StartCoroutine(WaitForDestroy());
            
        }
    }
    
    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
