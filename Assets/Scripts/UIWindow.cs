using UnityEngine;
using System.Collections;

public class UIWindow : MonoBehaviour {

    private Animator animator;

    public bool IsOpened
    {
        get { return animator.GetBool("isOpened"); }
        set
        {
            if (!gameObject.activeInHierarchy) gameObject.SetActive(true);
            if (value) transform.SetAsFirstSibling();
            animator.SetBool("isOpened", value);
        }
    }

    void OnEnable()
    {
        if (animator) return;
        animator = GetComponent<Animator>();
    }
}
