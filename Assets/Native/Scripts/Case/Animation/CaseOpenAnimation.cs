using UnityEngine;

public class CaseOpenAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Play()
    {
        animator.Play("chest_open");
    }
}
