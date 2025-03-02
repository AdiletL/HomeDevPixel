using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Puzzle {

public class CharacterPickUp : MonoBehaviour
{
    public Transform holdPoint;
    public Liftable liftedObject;
    
    HashSet<Liftable> objectsInRange = new HashSet<Liftable>();

    Coroutine liftCoroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && liftedObject != null)
        {
            if(liftCoroutine != null)
            {
                StopCoroutine(liftCoroutine);
            }

            Drop();

            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            TryLiftObject();
        }
    }

    public void TryLiftObject()
    {
        if (objectsInRange.Count > 0)
        {
            var nearest = objectsInRange
                .OrderBy(obj => Vector3.Distance(transform.position, obj.transform.position))
                .First();
            
            if (nearest.TryGetComponent(out Liftable objLiftable))
            {
                liftedObject = objLiftable;
                StartCoroutine(Lift(liftedObject));
            }
        }
    }

    IEnumerator Lift(Liftable liftable)
    {
        float duration = 0.5f;
        float t = 0;

        liftable.rb.isKinematic = true;
        liftable.col.enabled = false;

        objectsInRange.Remove(liftable);

        liftable.transform.SetParent(holdPoint);

        while(t <= 1)
        {
            t += Time.deltaTime / duration;

            if (liftable != null)
            {
                liftable.transform.position = Vector3.Lerp(liftable.transform.position, holdPoint.position, t);
                liftable.transform.rotation = Quaternion.Lerp(liftable.transform.rotation, holdPoint.rotation, t);
            }

            yield return null;
        }
    }

    public void Drop()
    {
        if(liftedObject == null) return;

        liftedObject.transform.parent = null;
        liftedObject.rb.isKinematic = false;
        liftedObject.col.enabled = true;
        liftedObject = null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Liftable objLiftable))
        {
            objectsInRange.Add(objLiftable);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Liftable objLiftable))
        {
            objectsInRange.Remove(objLiftable);
        }
    }
}

}