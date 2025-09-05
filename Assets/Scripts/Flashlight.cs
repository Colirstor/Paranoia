using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight; // ������ �� ��������� Light ��� �������� 
    // Update is called once per frame
    void Update()
    {
       // ���������/���������� �������� ��� ������� ������� R
       if (Input.GetKeyDown(KeyCode.R))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
