using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InvetorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InvetoryItem invetoryItem = eventData.pointerDrag.GetComponent<InvetoryItem>();
            invetoryItem.parentAfterDrag = transform;
        }
    }
}