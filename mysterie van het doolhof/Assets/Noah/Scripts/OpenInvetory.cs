using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInvetory : MonoBehaviour
{
    public GameObject canvas; // Sleep de Canvas hier in via de Inspector

    void Start()
    {
        canvas.SetActive(false); // Canvas onzichtbaar maken bij start
    }
}
