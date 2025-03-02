using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;

    private bool isStartedGame;
    private bool isPaused;


    private void OnEnable()
    {
        MenuPopUp.OnClickedStart += OnClickedStart;
        MenuPopUp.OnClickedExit += OnClickedExit;
        RestartPopUp.OnClickedRestart += OnClickedRestart;
    }

    private void OnDisable()
    {
        MenuPopUp.OnClickedStart -= OnClickedStart;
        MenuPopUp.OnClickedExit -= OnClickedExit;
        RestartPopUp.OnClickedRestart -= OnClickedRestart;
    }

    private void Start()
    {
        ExecutePause();
    }

    private void Update()
    {
        if(!isStartedGame) return;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) ExecutePause();
            else ExecuteResume();
        }
    }

    public void PlayBackgroundMusic() => backgroundMusic.Play();
    public void StopBackgroundMusic() => backgroundMusic.Stop();

    private void ExecutePause()
    {
        isPaused = true;
        Time.timeScale = 0;
        MainCanvas.Instance.ShowMenuPopUp();
    }

    private void ExecuteResume()
    {
        isPaused = false;
        Time.timeScale = 1;
        MainCanvas.Instance.HideMenuPopUp();
    }

    private void OnClickedRestart()
    {
        SceneManager.LoadSceneAsync("Gameplay");
    }
    
    private void OnClickedStart()
    {
        ExecuteResume();
        PlayBackgroundMusic();
        isStartedGame = true;
    }

    private void OnClickedExit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Остановить игру в редакторе
#else
        Application.Quit(); // Закрыть приложение в билде
#endif
    }
}
