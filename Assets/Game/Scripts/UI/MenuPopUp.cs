using System;
using UnityEngine;

public class MenuPopUp : MonoBehaviour
{
    public static event Action OnClickedStart;
    public static event Action OnClickedExit;
    
    public void OnClickStartBtn() => OnClickedStart?.Invoke();
    public void OnClickExitBtn() => OnClickedExit?.Invoke();
}
