using System;
using UnityEngine;

public class RestartPopUp : MonoBehaviour
{
    public static Action OnClickedRestart;
    
    public void ClickRestart() => OnClickedRestart?.Invoke();
}
