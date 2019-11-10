using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    [SerializeField]
    private GameObject loseAnimation;
    [SerializeField]
    private GameObject losePanel;
	[SerializeField]
	private GameObject AdButton;
	[SerializeField]
	private GameObject TryAgainButton;
    [SerializeField]
    private Text scoreNumber;
	[SerializeField]
	private Text highscoreNumber;
    [SerializeField]
    private Text ShaposText;

    public static bool isDead = false;
    private bool deadAnimation = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    void Update()
    {
        if (isDead && !deadAnimation)
        {   
			deadAnimation = true;
            GameObject loseAnimGO = (GameObject)Instantiate(loseAnimation, new Vector2(0, -1), Quaternion.identity);
            ParticleSystem loseAnim = loseAnimGO.GetComponent<ParticleSystem>();
            loseAnim.Play();
            Destroy(loseAnimGO, 2f);
            Invoke("ShowDeadPanel", 0.5f);
        }
    }

    public void RetryLevel()
    {
		losePanel.SetActive(false);
		isDead = false;
		deadAnimation = false;

		AdButton.SetActive (true);
		ShaposText.color = new Color32 (237, 242, 244, 255);

        PointsAndCombos.playerScore = 0;
        SceneManager.LoadScene("MainScene");
    }

    public void ToStartMenu()
    {
        
		losePanel.SetActive(false);
		isDead = false;
        deadAnimation = false;
        SceneManager.LoadScene(0);
        
    }

    void ShowDeadPanel()
    {
        losePanel.SetActive(true);

		// Current score
		scoreNumber.text = PointsAndCombos.playerScore.ToString();

		// Current earned shapos
        int initialShapos = PlayerPrefs.GetInt("shapos", 0);
        int earnedShapos = (int)(PointsAndCombos.playerScore * 0.01);
        int currentShapos = initialShapos + earnedShapos;
        ShaposText.text = earnedShapos.ToString();
        PlayerPrefs.SetInt("shapos", currentShapos);

		// Player highscore
		int highscore = PlayerPrefs.GetInt("highscore", 0);
		if (PointsAndCombos.playerScore > highscore) {
			PlayerPrefs.SetInt ("highscore", PointsAndCombos.playerScore);
		}
		highscoreNumber.text = PlayerPrefs.GetInt ("highscore").ToString ();
    }

	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");

			AdButton.SetActive (false);

			// Duoble the earned shapos
			int initialShapos = PlayerPrefs.GetInt ("shapos", 0);
			int earnedShapos = (int)(PointsAndCombos.playerScore * 0.01);
			int currentShapos = initialShapos + earnedShapos;


			ShaposText.text = (earnedShapos * 2).ToString ();
			PlayerPrefs.SetInt ("shapos", currentShapos);

			ShaposText.color = new Color32 (217, 4, 41, 255);

			Sequence comboSequence = DOTween.Sequence();
			comboSequence.Append(ShaposText.transform.DOScale(3f,0.4f));
			comboSequence.Append(ShaposText.transform.DOScale(1f, 0.4f));

			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
}