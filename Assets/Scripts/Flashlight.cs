using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight; // Ссылка на компонент Light для фонарика 
    // Update is called once per frame
    void Update()
    {
       // Включение/выключение фонарика при нажатии клавиши R
       if (Input.GetKeyDown(KeyCode.R))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
