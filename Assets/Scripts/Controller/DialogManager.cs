
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject dialog;
    public Transform Initial;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(dialog, Initial.transform.position, quaternion.identity);
        }
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     Destroy(dialog);
    // }
}
