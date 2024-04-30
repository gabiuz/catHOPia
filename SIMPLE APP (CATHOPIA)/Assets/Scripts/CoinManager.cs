using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TextMeshProUGUI coinNumbers;

    void Update()
    {
        coinNumbers.text = coinCount.ToString();
    }
}

