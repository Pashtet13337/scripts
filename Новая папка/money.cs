using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour {
	public int Cena; // установим цену нашей монеты (т.е. какое количество монет будет прибавляться при сборе определенной монеты)


	void OnTriggerEnter2D(Collider2D col) { // триггер монеты, реагирует при взаимодействии с монетой (при входе игрока в триггер нашей монеты)
		money_player.money += Cena; // добавляем монеты в указанную ссылку
		GameObject.FindGameObjectWithTag ("Player").GetComponent<money_player> ().TextMoney.text = money_player.money.ToString(); // вывод количеста монет на экран
		Destroy (gameObject); // удаление монеты с данной игровой сцены 
		}
}

