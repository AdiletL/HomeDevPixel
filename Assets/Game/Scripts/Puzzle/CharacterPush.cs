using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Puzzle {

[RequireComponent(typeof(Collider))]
public class CharacterPush : MonoBehaviour
{
    Pushable pushable = null;
    HashSet<Pushable> pushables = new HashSet<Pushable>();
    bool canPush = false;

    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    void FixedUpdate()
    {
        if(pushables.Count > 0)
        {
            for(int i = 0; i < pushables.Count; i++)
            {
                pushables.ElementAt(i).Push(this);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out pushable))
        {
            pushables.Add(pushable);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out pushable))
        {
            pushables.Remove(pushable);
        }
    }
}

}