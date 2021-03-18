using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _menuSceneIndex;

    private void OnEnable()
    {
        _player.Dying += PlayerDying;
    }

    private void OnDisable()
    {
        _player.Dying -= PlayerDying;
    }

    private void PlayerDying()
    {
       SceneManager.LoadScene(_menuSceneIndex);
    }
}