using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler: MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioSource _pressSound;
    [SerializeField] private AudioSource _hoverSound;
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        _hoverSound.Play();
    }

    public void OnClickSound()
    {
        _pressSound.Play(); 
    }
}
