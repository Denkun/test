using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Floor_gen : MonoBehaviour {
	GameObject Level_intro;
	GameObject EnemyHPGO;
	Text AttackButtonText;
	Text FloorText;
	Text EnemyHP;
	Text HP;
	int floor = 1;
	int EnemyHealth;
	int EnemyDefence;
	int EnemyAttack;
	int Wins;
	bool inFight;

	public GameObject [] Monsters;
	public GameObject [] BackGrounds;
	public float TimeDelay = 2f;

	void Start(){
		FloorText = GameObject.Find ("Floor").GetComponent<Text> ();
		HP = GameObject.Find ("HP").GetComponent<Text> ();
		EnemyHPGO = GameObject.Find ("EnemyHealthPoint");
		Level_intro = GameObject.Find ("Level_intro");
		AttackButtonText = GameObject.Find ("AttackButtonText").GetComponent<Text> ();
		InitGame ();
	}
	
	void InitGame(){
		Level_intro.SetActive (true);
		FloorText.text = "Floor " + floor;
		HP.text = "HP: " + Knight.Health;
		EnemyHPGO.SetActive (false);

		Generate_event ();
		Generate_floor ();
		Invoke ("Hide_intro", TimeDelay);
	}

	void Generate_event(){
		if (Random.Range (1, 100) < 75) {
			EnemyHealth = Random.Range (1 + floor, 15 + floor);
			EnemyDefence = Random.Range (0 + floor, 10 + floor);
			EnemyAttack = Random.Range (0 + floor, 10 + floor);
			EnemyHPGO.SetActive (true);
			EnemyHP = GameObject.Find ("EnemyHealthPoint").GetComponent<Text> ();
			EnemyHP.text = "Enemy HP: " + EnemyHealth;
			GameObject toInstantiate = Monsters [Random.Range(0, Monsters.Length)];
			GameObject Instance = Instantiate (toInstantiate, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;

			inFight = true;
			AttackButtonText.text = "Attack";
		} else {
			Knight.Health += 5;
			inFight = false;
			AttackButtonText.text = "Next Floor";
			HP.text = "HP: " + Knight.Health;
		}
	}

	void Generate_floor(){
		GameObject toInstantiate = BackGrounds [Random.Range (0, BackGrounds.Length)];
		GameObject Instance = Instantiate (toInstantiate, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
	}

	void Hide_intro(){
		Level_intro.SetActive (false);
	}

	public void Leave(){
		Application.LoadLevel ("Main_menu");
	}

	void GetHit(){
		int Damage;
		Damage = Knight.Attack - EnemyDefence / 2;
		if (Damage > 0)
			EnemyHealth -= Damage;
		Damage = EnemyAttack - Knight.Defence / 2;
		if (Damage > 0)
			Knight.Health -= Damage;
		EnemyHP.text = "Enemy HP: " + EnemyHealth;
		HP.text = "HP: " + Knight.Health;
		if (EnemyHealth <= 0) {
			EnemyHP.text = "Enemy HP: 0";
			Wins++;
			inFight = false;
			AttackButtonText.text = "Next Floor";
		}
		if (Knight.Health <= 0) {
			Level_intro.SetActive (true);
			FloorText.text = "You survaved " + floor + " floors\nYou slay " + Wins + " monsters";
			Invoke ("Leave", 5f);
		}
	}

	public void Attack_Button(){
		if (inFight) {
			GetHit ();
		} else {
			floor++;
			InitGame ();
		}
	}
}
