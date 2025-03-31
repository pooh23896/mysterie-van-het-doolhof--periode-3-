using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectOnClick : MonoBehaviour
{
    public GameObject objectToHide; // Sleep hier het object in dat moet verdwijnen

    void OnMouseDown()
    {
        if (objectToHide != null)
        {
            objectToHide.SetActive(false);
        }
    }
}