using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
	private int score = 0;
	[SerializeField] private TMP_Text scoreText;
	private void Start()
	{
		GameManager.Instance.OnDuckKilled += updateScore;
	}
	private void updateScore()
	{
		++score;
		scoreText.text = $"Score: {score}";
	}
}
