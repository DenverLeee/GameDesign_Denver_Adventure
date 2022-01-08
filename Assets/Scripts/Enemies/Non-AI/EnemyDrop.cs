using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameObject[] orange;

    public void getOrange()
    {
        Vector3 pos = transform.position;
        Instantiate(orange[Random.Range(0, orange.Length)], pos, Quaternion.identity);
        Destroy(gameObject);
    }
}
