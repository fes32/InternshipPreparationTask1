using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    public int CountOfCoins { get; private set; } = 0;

    public event UnityAction<int> CountOfCoinsChanged;

    public void AddCoin()
    {
        CountOfCoins++;
        CountOfCoinsChanged?.Invoke(CountOfCoins);
    }
}