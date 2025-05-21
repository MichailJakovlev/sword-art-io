using UnityEngine;

public class CaseOpenAnimation : MonoBehaviour
{
    [SerializeField] public Animator caseOpenAnimator;

    public void Play()
    {
        caseOpenAnimator.Play("chest_open");
    }

}
