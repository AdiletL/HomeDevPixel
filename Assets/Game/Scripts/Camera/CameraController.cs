using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float FOVInHome = 40;
    [SerializeField] private float FOVOutsideHome = 40;
    [SerializeField] private float FOVSpeed = 2;
    
    private CinemachineCamera cinemachineCamera;
    private bool isInHome;
    
    public static CameraController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    private void Update()
    {
        if (isInHome) ChangeFOV(FOVInHome);
        else ChangeFOV(FOVOutsideHome);
    }

    private void ChangeFOV(float newFOV)
    {
        float currentFOV = cinemachineCamera.Lens.FieldOfView;
        cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(currentFOV, newFOV, Time.deltaTime * FOVSpeed);
    }
    
    public void ExecuteOutsideHome() => isInHome = false;
    public void ExecuteInHome() => isInHome = true;
}
