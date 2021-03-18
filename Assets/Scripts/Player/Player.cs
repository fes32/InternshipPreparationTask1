using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    private PlayerMovement _movement;
    private Wallet _coinWallet;

    public event UnityAction Dying; 

    private void OnEnable()
    {
        _movement = GetComponent<PlayerMovement>();
        _coinWallet = GetComponent<Wallet>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Coin coin))
        {
            _coinWallet.AddCoin();
            coin.gameObject.SetActive(false);
        }

        else if (other.gameObject.GetComponent<Barrier>())
        {
            Dying?.Invoke();
        }
    }

}