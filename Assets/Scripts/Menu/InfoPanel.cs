using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private GameObject _panel;

    public event UnityAction Closed;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(Disable);   
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(Disable);
    }

    private void Disable()
    {
        _panel.SetActive(false);
        Closed?.Invoke();
    }

    public void Activate()
    {
        _panel.SetActive(true);
    }
}