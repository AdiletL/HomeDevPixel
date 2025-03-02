using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject menuPopUp;
    [SerializeField] private GameObject restartPopUp;
    
    
    public static MainCanvas Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    
    public void SetObjectInParent(GameObject go) => go.transform.SetParent(parent);
    
    public void ShowMenuPopUp() => menuPopUp.SetActive(true);
    public void HideMenuPopUp() => menuPopUp.SetActive(false);
    
    public void ShowRestartPopUp() => restartPopUp.SetActive(true);
    public void HideRestartPopUp() => restartPopUp.SetActive(false);
}
