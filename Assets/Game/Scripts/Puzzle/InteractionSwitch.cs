using UnityEngine;
using UnityEngine.Events;

namespace Puzzle {

public class InteractionSwitch : MonoBehaviour, IInteractble
{
    public UnityEvent onSwitchOn;
    public UnityEvent onSwitchOff;
    public bool isOn = false;

    public void Interact()
    {
        if (isOn)
        {
            onSwitchOff.Invoke();
        }
        else
        {
            onSwitchOn.Invoke();
        }

        isOn = !isOn;
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