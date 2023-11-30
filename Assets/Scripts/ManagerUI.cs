using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] Button _startButton;
    [SerializeField] Button _exitButton;
    [SerializeField] RectTransform _mainMenu;
    [SerializeField] EventSystem _eventSystem;

    [SerializeField, Range(5, 10)] float _expandDuration;

    void Start()
    {
        StartCoroutine(StartGameMenuAnimation());
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartingGame);
        _exitButton.onClick.AddListener(CloseGame);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartingGame);
        _exitButton.onClick.RemoveListener(CloseGame);
    }

    private IEnumerator StartGameMenuAnimation()
    {
        _mainMenu.localScale = new Vector2(0, 1);
        _eventSystem.enabled = false;
        float _timeElapsed = 0f;

        while(_timeElapsed < _expandDuration)
        {
            float time = _timeElapsed / _expandDuration;

            _mainMenu.localScale = Vector2.Lerp(_mainMenu.localScale, new Vector2(1, 1), time);

            _timeElapsed += Time.deltaTime;
            yield return null;
        }

        _mainMenu.localScale = new Vector2(1, 1);
        _eventSystem.enabled = true;          
    }

    private void StartingGame()
    {
        SceneManager.LoadScene("Arcanoid");
    }

    private void CloseGame()
    {
        EditorApplication.isPlaying = false;
    }
}
