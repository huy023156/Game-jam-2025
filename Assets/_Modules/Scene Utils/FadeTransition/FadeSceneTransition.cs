using System.Collections;
using UnityEngine;

public class FadeTransition : MonoBehaviour {
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public IEnumerator FadeIn() {
        animator.SetTrigger("fade_in");
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animationLength);
    }

    public IEnumerator FadeOut() {
        animator.SetTrigger("fade_out");
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animationLength);
    }
}
