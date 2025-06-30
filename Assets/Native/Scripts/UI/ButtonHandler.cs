using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler: MonoBehaviour, IPointerEnterHandler
{
    public AudioSource _pressSound;
    public AudioSource _hoverSound;
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        _hoverSound.Play();
    }

    public void OnClickSound()
    {
        _pressSound.Play(); 
    }
}
