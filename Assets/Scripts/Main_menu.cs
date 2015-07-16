using UnityEngine;
using System.Collections;

public class Main_menu : MonoBehaviour {

	public void Startgame(){
		Application.LoadLevel ("Knight_Create");
	}

	public void Exitgame(){
		Application.Quit();
	}
}
