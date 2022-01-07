using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrangeUI : MonoBehaviour
{
    public int startOrangeNumber;
    public Text orangeNumber;
    public static int currentOrangeNumber;

    private void Start()
    {
        currentOrangeNumber = startOrangeNumber;
    }

    private void Update()
    {
        orangeNumber.text = currentOrangeNumber.ToString();
    }
}
