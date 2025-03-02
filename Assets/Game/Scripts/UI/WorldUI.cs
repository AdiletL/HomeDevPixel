using System;
using UnityEngine;

public class WorldUI : MonoBehaviour
{
    [SerializeField] private Transform parent;
    public static WorldUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SetObjectInParent(GameObject go) => go.transform.SetParent(parent);
}
