using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ButtonHandler: MonoBehaviour, IPointerEnterHandler
{
    private AudioSource _pressSound;
    private AudioSource _hoverSound;
    
    private AudioData _audioData;
    
    [Inject]
    private void Construct(AudioData audioData)
    {
        _audioData = audioData;
    }
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        _audioData.buttonHoverSound.Play();
    }

    public void OnClickSound()
    {
        _audioData.buttonPressSound.Play();
    }
}
