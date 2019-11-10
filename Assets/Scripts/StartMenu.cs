using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {


    [SerializeField]
    private Image musicButton;
    [SerializeField]
    private Image soundsButton;

    [SerializeField]
    private Sprite musicButtonON;
    [SerializeField]
    private Sprite soundsButtonON;
    [SerializeField]
    private Sprite musicButtonOFF;
    [SerializeField]
    private Sprite soundsButtonOFF;


    public void StartGame()
    {
        if (PlayerPrefs.GetInt("first_time",0) == 0)
        {
			PlayerPrefs.SetInt("first_time", 1);
			PlayerPrefs.SetInt("bg_skin_0_active", 1);
			PlayerPrefs.SetInt("bg_skin_1_active", 0);

            SceneManager.LoadScene("Instructions");
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }
        
    }

    public void Achievements()
    {
        SceneManager.LoadScene("Achievements");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Inventory()
    {
        SceneManager.LoadScene("Inventory");
    }

    public void ToStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void changeMusicVolume()
    {
        if (PlayerPrefs.GetInt("music_volume", 1) == 1)
        {
            musicButton.sprite = musicButtonOFF;
            PlayerPrefs.SetInt("music_volume", 0);
        }
        else
        {
            musicButton.sprite = musicButtonON;
            PlayerPrefs.SetInt("music_volume", 1);
        }
    }

    public void changeSoundsVolume()
    {
        if (PlayerPrefs.GetInt("sounds_volume", 1) == 1)
        {
            soundsButton.sprite = soundsButtonOFF;
            PlayerPrefs.SetInt("sounds_volume", 0);
        }
        else
        {
            soundsButton.sprite = soundsButtonON;
            PlayerPrefs.SetInt("sounds_volume", 1);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnStartMenuFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnStartMenuFinishedLoading;
    }

    void OnStartMenuFinishedLoading(Scene scene, LoadSceneMode mode)
    {
		if (PlayerPrefs.GetInt("first_time",0) == 0)
		{
			PlayerPrefs.SetInt ("ov_skin_0_active", 1);
			PlayerPrefs.SetInt ("bg_skin_0_active", 1);
		}
        if (PlayerPrefs.GetInt("music_volume", 1) == 0)
        {
            musicButton.sprite = musicButtonOFF;
        }

        if (PlayerPrefs.GetInt("sounds_volume", 1) == 0)
        {
            soundsButton.sprite = soundsButtonOFF;
        }
    }
}
