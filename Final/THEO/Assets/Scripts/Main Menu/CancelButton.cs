using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CancelButton : MonoBehaviour
{
    [SerializeField] private AudioClip pointerEnterSound;
    [SerializeField] private AudioClip pointerClickSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.instance.PlaySound(pointerEnterSound);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.instance.PlaySound(pointerClickSound);
    }
}
