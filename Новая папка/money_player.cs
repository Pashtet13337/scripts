using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class money_player : MonoBehaviour {
	
	static public int money; // переменная для монет 

	[SerializeField]
	public Text TextMoney; //в данную ссылку будем переносить текстовую информацию о монетах


	void Start(){
		money = 0; // по умолчанию, при запуске сцены количество монет = 0
	}
}
