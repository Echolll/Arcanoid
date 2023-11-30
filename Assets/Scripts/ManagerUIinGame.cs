using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class ManagerUIinGame : MonoBehaviour
{
    [Header("—сылка на кнопки")]
    [SerializeField] private Button _resumeGame;
    [SerializeField] private Button _restartGame;
    [SerializeField] private Button _exitGame;

    [Header("—сылка на меню")]
    [SerializeField] private GameObject _menuPlayerOne;
    [SerializeField] private GameObject _menuPlayerTwo;

    [Header("—сылка на список из сердечек")]
    [SerializeField] private List<GameObject> _playerOneHealth;
    [SerializeField] private List<GameObject> _playerTwoHealth;

    [SerializeField] private bool _inPause;

    PlayersControl _input;

    private void Awake()
    {
        _input = new PlayersControl();
    }

    private void OnEnable()
    {
         _input.Enable();
         _input.Moving.PauseGame.performed += callBackContext => PauseGame();
         _resumeGame.onClick.AddListener(ResumeGame);
         _restartGame.onClick.AddListener(RestartGame);
         _exitGame.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
         _input.Disable();
         _resumeGame.onClick.RemoveListener(ResumeGame);
         _restartGame.onClick.RemoveListener(RestartGame);
         _exitGame.onClick.RemoveListener(ExitGame);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        _menuPlayerOne.SetActive(true);
        _menuPlayerTwo.SetActive(true);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        _menuPlayerOne.SetActive(false);
        _menuPlayerTwo.SetActive(false);
    }

    private void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ExitGame()
    {
        EditorApplication.isPlaying = false;
    }
 
}
