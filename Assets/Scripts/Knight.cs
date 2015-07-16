using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Knight : MonoBehaviour {

	static public int Health;
	static public int Defence;
	static public int Attack;

	Text HealthText;
	Text DefenceText;
	Text AttackText;

	public void GoToDungeon(){
		Application.LoadLevel ("Game");
	}

	void Start(){
		Health = Random.Range(15, 25);
		Defence = Random.Range(5, 20);
		Attack = Random.Range(5, 20);
		HealthText = GameObject.Find("HP").GetComponent<Text>();
		DefenceText = GameObject.Find("Defense").GetComponent<Text>();
		AttackText = GameObject.Find("Attack").GetComponent<Text>();
		Update ();
	}

	public void GenerateAgain(){
		Health = Random.Range(15, 25);
		Defence = Random.Range(5, 20);
		Attack = Random.Range(5, 20);
	}

	void Update(){
		HealthText.text = "Health: " + Health;
		DefenceText.text = "Defence: " + Defence;
		AttackText.text = "Attack: " + Attack;
	}
}
