using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
	[Header("PowerUps")]
    [SerializeField]
    private Text multiplierCount;
    [SerializeField]
    private Text bonusLiveCount;

    [SerializeField]
    private Toggle multiplierToggle;
    [SerializeField]
    private Toggle bonusLiveToggle;

    private int _multiplier;
    private int _bonusLive;

	[Header("Background Skins")]
	[SerializeField]
	private int numberOfBgSkinPacks = 0;
	[SerializeField]
	private Toggle[] backgroundSkinToggles;

	[Header("Overlays Skins")]
	[SerializeField]
	private int numberOfSkinPacks = 0;
	[SerializeField]
	private Toggle[] overlaysSkinToggles;

	public void ToggleMultiplier()
    {
        if (multiplierToggle.isOn)
        {
            PlayerPrefs.SetInt("powerup_multiplier_active", 1);
        }
        else
        {
            PlayerPrefs.SetInt("powerup_multiplier_active", 0);
        }

    }

    public void ToggleBonusLive()
    {
        if (bonusLiveToggle.isOn)
        {
            PlayerPrefs.SetInt("powerup_bonuslive_active", 1);
        }
        else
        {
            PlayerPrefs.SetInt("powerup_bonuslive_active", 0);
        }

    }

	public void ToggleSkin(int skinNumber)
	{
		string playerPrefName = "ov_skin_" + skinNumber + "_active";

		if (overlaysSkinToggles[skinNumber].isOn)
		{
			PlayerPrefs.SetInt(playerPrefName, 1);
		}
		else
		{
			PlayerPrefs.SetInt(playerPrefName, 0);
		}
	}

	public void ToggleBg(int bgNumber)
	{
		string playerPrefName = "bg_skin_" + bgNumber + "_active";

		if (backgroundSkinToggles[bgNumber].isOn)
		{
			PlayerPrefs.SetInt(playerPrefName, 1);
		}
		else
		{
			PlayerPrefs.SetInt(playerPrefName, 0);
		}
	}

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ToShop()
    {
        SceneManager.LoadScene("Shop");
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnInventoryFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnInventoryFinishedLoading;
    }

    void OnInventoryFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        // PowerUps
		_multiplier = PlayerPrefs.GetInt("powerup_multiplier_count", 0);
        _bonusLive = PlayerPrefs.GetInt("powerup_bonuslive_count", 0);

        multiplierCount.text = _multiplier.ToString();
        bonusLiveCount.text = _bonusLive.ToString();

        if (_multiplier == 0)
        {
            multiplierToggle.interactable = false;
            multiplierToggle.isOn = false;
            PlayerPrefs.SetInt("powerup_multiplier_active", 0);
        }
        if (_bonusLive == 0)
        {
            bonusLiveToggle.interactable = false;
            bonusLiveToggle.isOn = false;
            PlayerPrefs.SetInt("powerup_bonuslive_active", 0);
        }

        if (PlayerPrefs.GetInt("powerup_multiplier_active", 0) == 0)
        {
            multiplierToggle.isOn = false;
        }
        if (PlayerPrefs.GetInt("powerup_bonuslive_active", 0) == 0)
        {
            bonusLiveToggle.isOn = false;
        }

		// Backgrounds
		for (int i = 0; i < numberOfBgSkinPacks; i++) {
			string playerPrefName = "bg_skin_" + i + "_active";
			if (PlayerPrefs.GetInt (playerPrefName, 0) == 0) {
				backgroundSkinToggles [i].isOn = false;
			} else {
				backgroundSkinToggles [i].isOn = true;
			}
		}

		// Overlays skins
		for (int i = 0; i < numberOfSkinPacks; i++) {
			string playerPrefName = "ov_skin_" + i + "_active";
			if (PlayerPrefs.GetInt (playerPrefName, 0) == 0) {
				overlaysSkinToggles [i].isOn = false;
			} else {
				overlaysSkinToggles [i].isOn = true;
			}
		}

    }
}
