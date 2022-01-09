using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    private Animator animator;
    private bool canGoNext = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (OrangeUI.currentOrangeNumber >= 20)
        {
            animator.SetTrigger("NextLevel");
            canGoNext = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canGoNext)
        {
            CharacterController2D.animator.SetBool("CanGoNext",true);
            CharacterController2D.canMove = false;
            StartCoroutine(WaitToGoNext());
        }
    }
    
    IEnumerator WaitToGoNext()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}


