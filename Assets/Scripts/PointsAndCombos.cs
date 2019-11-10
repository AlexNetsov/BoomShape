using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PointsAndCombos : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    public static int playerScore;

    [SerializeField]
    private Text comboText;
    public static bool showComboText;

    [SerializeField]
    private Text livesText;
    public static int currentLives;


    void Start () {
        currentLives = 2;
        playerScore = 0;
        showComboText = false;
    }

    void Update()
    {
        scoreText.text = playerScore.ToString();
        if (currentLives < 0)
        {
            livesText.text = "0";
        }
        else
        {
            livesText.text = currentLives.ToString();
        }       

        if (showComboText)
        {
			comboText.text = "+" + 100 * Multiplier.currentMultiplier;
			comboText.color = new Color(Random.Range(0.9f,1f), Random.Range(0f, 1f), Random.Range(0f, 0.1f), 1f);
            Sequence comboSequence = DOTween.Sequence();
            comboSequence.Append(comboText.DOFade(255, 0f));
            comboSequence.Append(comboText.transform.DOScale(3f,0.3f));
            comboSequence.Append(comboText.transform.DOScale(1f, 0.3f));
            comboSequence.Append(comboText.DOFade(0, 0f));
            comboSequence.Insert(0, comboText.transform.DORotate(new Vector3(0f, 0f, Random.Range(-25, 26)), comboSequence.Duration() / 4));

            showComboText = false;
        }
    }
}
