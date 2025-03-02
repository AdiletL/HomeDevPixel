using UnityEngine;
using UnityEngine.Events;

namespace Puzzle {

public class InteractionButton : MonoBehaviour, IInteractble
{
    public UnityEvent onPress;
    public UnityEvent onRelease;

    public bool isPressed = false;

    public void Interact()
    {
        if (isPressed)
        {
            onRelease.Invoke();
        }
        else
        {
            onPress.Invoke();
        }

        isPressed = !isPressed;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out CharacterInteraction characterInteraction))
        {
            characterInteraction.AddInteraction(this);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out CharacterInteraction characterInteraction))
        {
            characterInteraction.RemoveInteraction(this);
        }
    }

        public Transform GetTransform() => transform;
    }

}