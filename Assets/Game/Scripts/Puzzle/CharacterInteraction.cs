using System.Collections.Generic;
using UnityEngine;

namespace Puzzle {

public class CharacterInteraction : MonoBehaviour
{
    public HashSet<IInteractble> iInteractble = new();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && iInteractble != null)
        {
            Interact();
        }
    }

    public void Interact()
    {
        float minDistance = float.MaxValue;
        IInteractble closestInteractble = null;

        foreach (var interactble in iInteractble)
        {
            if (interactble == null) continue;

            float distance = Vector3.Distance(transform.position, interactble.GetTransform().position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestInteractble = interactble;
            }
        }

        if (closestInteractble != null)
        {
            closestInteractble.Interact();
        }
    }

    public void RemoveInteraction(IInteractble interactble)
    {
        iInteractble.Remove(interactble);
    }
    
    public void AddInteraction(IInteractble interactble)
    {
        iInteractble.Add(interactble);
    }
}

}