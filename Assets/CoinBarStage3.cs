using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBarStage3 : MonoBehaviour
{
    public Slider slider;
    public void SetMaxCoins(int Coins)
	{
		slider.maxValue = Coins;
		slider.value = Coins;
	}

    public void SetCoins(int Coins)
	{
		slider.value = Coins;
	}
}
