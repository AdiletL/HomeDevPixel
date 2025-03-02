using System;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class Ladder : MonoBehaviour
{
    private BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }
}
