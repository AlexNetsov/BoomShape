using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Shop : MonoBehaviour {

    [SerializeField]
    private Text playerShapos;

    [Header("Multiplier Settings")]
    [SerializeField]
    private Text multiplierPackPrice;
    [SerializeField]
    private int mPackPriceInt = 420;
    [SerializeField]
    private Text multiplierPackSizeText;
    [SerializeField]
    private int mPackSize = 5;

    [Header("Bonus Live Settings")]
    [SerializeField]
    private Text bonusLivePackPrice;
    [SerializeField]
    private int blPackPriceInt = 380;    
    [SerializeField]
    private Text bonusLivePackSizeText;   
    [SerializeField]
    private int blPackSize = 5;

    [Header("Messages")]
    [SerializeField]
    private GameObject succcesMessage;
    [SerializeField]
    private GameObject failMessage;

    void Start () {

        multiplierPackPrice.text = mPackPriceInt.ToString();
        bonusLivePackPrice.text = blPackPriceInt.ToString();

        multiplierPackSizeText.text = mPackSize.ToString();
        bonusLivePackSizeText.text = blPackSize.ToString();

        playerShapos.text = PlayerPrefs.GetInt("shapos", 0).ToString();

    }

    void Update()
    {
        playerShapos.text = PlayerPrefs.GetInt("shapos", 0).ToString();
    }
    public void PurchaseMultiplierPack()
    {

        int currentShapos = PlayerPrefs.GetInt("shapos", 0);
        if (currentShapos >= mPackPriceInt)
        {
            int multiplierCount = PlayerPrefs.GetInt("powerup_multiplier_count", 0);
            multiplierCount +=  mPackSize;
            PlayerPrefs.SetInt("powerup_multiplier_count", multiplierCount);

            currentShapos -= mPackPriceInt;
            PlayerPrefs.SetInt("shapos", currentShapos);

            failMessage.SetActive(false);
            succcesMessage.SetActive(true);

            playerShapos.text = PlayerPrefs.GetInt("shapos", 0).ToString();
        }
        else
        {
            succcesMessage.SetActive(false);
            failMessage.SetActive(true);
        }

    }

    public void PurchaseBonusLivePack()
    {

        int currentShapos = PlayerPrefs.GetInt("shapos", 0);
        if (currentShapos >= blPackPriceInt)
        {
            int bonusLiveCount = PlayerPrefs.GetInt("powerup_bonuslive_count", 0);
            bonusLiveCount += blPackSize;
            PlayerPrefs.SetInt("powerup_bonuslive_count", bonusLiveCount);

            currentShapos -= blPackPriceInt;
            PlayerPrefs.SetInt("shapos", currentShapos);

            failMessage.SetActive(false);
            succcesMessage.SetActive(true);

            playerShapos.text = PlayerPrefs.GetInt("shapos", 0).ToString();
        }
        else
        {
            succcesMessage.SetActive(false);
            failMessage.SetActive(true);
        }

    }

    public void BackToHome()
    {
        SceneManager.LoadScene(0);
    }
}
