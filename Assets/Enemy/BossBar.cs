using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    public Slider slider;

	public void SetMaxBossHP(int health)
	{
		slider.maxValue = health;
		slider.value = health;
	}

    public void SetBossHP(int health)
	{
		slider.value = health;
	}
}
