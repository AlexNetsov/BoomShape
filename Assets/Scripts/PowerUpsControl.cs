using UnityEngine;
using UnityEngine.UI;
public class PowerUpsControl : MonoBehaviour {

    [SerializeField]
    private GameObject multiplierBonus;
    [SerializeField]
    private GameObject bonusLiveBonus;

    // Use this for initialization
    void Start () {

        int _multiplier = PlayerPrefs.GetInt("powerup_multiplier_count", 0);
        int _bonusLive = PlayerPrefs.GetInt("powerup_bonuslive_count", 0);
        // Multiplier PowerUp
        if (PlayerPrefs.GetInt("powerup_multiplier_active", 0) == 1)
        {

            int _redusedMultiplier = _multiplier - 1;
            multiplierBonus.GetComponentInChildren<Text>().text = _redusedMultiplier.ToString();
            PlayerPrefs.SetInt("powerup_multiplier_count", _redusedMultiplier);

            Multiplier.currentMultiplier = 3;
            Multiplier.refreshMultiplier = true;

            if (_redusedMultiplier == 0)
            {
                PlayerPrefs.SetInt("powerup_multiplier_active", 0);
            }

        }
        else
        {
            multiplierBonus.SetActive(false);
        }

        // BonusLive PowerUp
        if (PlayerPrefs.GetInt("powerup_bonuslive_active", 0) == 1)
        {
           
            int _redusedBonusLive = _bonusLive - 1;
            bonusLiveBonus.GetComponentInChildren<Text>().text = _redusedBonusLive.ToString();
            PlayerPrefs.SetInt("powerup_bonuslive_count", _redusedBonusLive);

            PointsAndCombos.currentLives++;

            if (_redusedBonusLive == 0)
            {
                PlayerPrefs.SetInt("powerup_bonuslive_active", 0);
            }

        }
        else
        {
            bonusLiveBonus.SetActive(false);
        }
        
    }
}
