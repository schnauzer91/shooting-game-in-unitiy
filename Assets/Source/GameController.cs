using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public float startWait = 3;
	public float spwanWait = 2;
	public float waveWait = 2;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	int score;
	bool gameOver;
	bool restart;

	void Start () {

		Screen.SetResolution (480, 800, false);

		score = 0;

		restartText.text = "";
		gameOverText.text = "";
		gameOver = false;
		restart = false;
		UpdateScore ();
		StartCoroutine(SpawnWaves());
	}

	public void AddScore(int newScore) {

		score += newScore;
		UpdateScore ();

	}

	public void GameOver () {

		gameOverText.text = "   Game Over";
		gameOver = true;

	}

	public void UpdateScore() {

		scoreText.text = "Score : " + score;

	}

	IEnumerator SpawnWaves() {
		// 코루틴
		yield return new WaitForSeconds(startWait);

		while(true) {

			for (int i = 0; i < 10; ++i) {
				GameObject hazard = hazards [Random.Range(0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range(-5, 5), 5, 16);
				Quaternion spawnRotation = Quaternion.Euler (new Vector3 (0, 180, 0));
				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds(spwanWait);
			}

			yield return new WaitForSeconds(waveWait);

			if (gameOver == true) {

				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	void Update () {
	
		if (restart == true) {

			if (Input.GetKeyDown (KeyCode.R) == true) {

				Application.LoadLevel (Application.loadedLevel);
				
			}
		}
	}
}
