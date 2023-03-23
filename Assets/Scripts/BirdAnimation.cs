using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    Animator animator;
    const string CHAR_FLY = "Fly"; // Name of animation must be the same with this string
    const string CHAR_DEAD = "Death";
    private string currentStates;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ChangeAnimationState(string newState)
    {
        if (currentStates == newState) return;
        animator.Play(newState);
        currentStates = newState;
    }

    void Update()
    {
        if (BirdController.FindObjectOfType<BirdController>().isAlive)
        {
            ChangeAnimationState(CHAR_FLY);
        }
        else
        {
            ChangeAnimationState(CHAR_DEAD);
        }
    }
}
