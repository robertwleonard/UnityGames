using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenuBtnManager : MonoBehaviour {

	public void NewGameBtn(string newGameLevel) {
		SceneManager.LoadScene(newGameLevel);
		Time.timeScale = 1;
	}

	public void ExitgameBtn() {
		Application.Quit();
	}
}
