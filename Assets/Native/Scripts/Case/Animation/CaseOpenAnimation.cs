using System.Collections;
using UnityEngine;
using Zenject;

public class CaseOpenAnimation : MonoBehaviour
{
    [SerializeField] public Animator caseOpenAnimator;
    
    private AudioData _audioData;
    
    [Inject]
    private void Construct(AudioData audioData)
    {
        _audioData = audioData;
    }
    
    public void Play()
    {
        StartCoroutine(DelayAudio(0));
        caseOpenAnimator.Play("chest_open");
    }

    IEnumerator DelayAudio(float waitTime)
    { 
        yield return new WaitForSeconds(waitTime);
        _audioData.openCaseSound.Play();
    }

}
