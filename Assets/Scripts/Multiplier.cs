using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Multiplier : MonoBehaviour {

    public static int currentMultiplier;
    public static bool refreshMultiplier;
    [SerializeField]
    private Text multiplierText;
    // Use this for initialization
	void Start () {
        currentMultiplier = 1;
        refreshMultiplier = false;
    }
	
	// Update is called once per frame
	void Update () {
        multiplierText.text = "x" + currentMultiplier;
           
        if (refreshMultiplier)
        {
            Sequence multiplierSequence = DOTween.Sequence();
            multiplierSequence.PrependInterval(0.1f);
            multiplierSequence.Append(multiplierText.transform.DOScale(3f, 0.3f));
            multiplierSequence.Append(multiplierText.transform.DOScale(1f, 0.3f));
            multiplierSequence.Insert(0, multiplierText.transform.DORotate(new Vector3(0f, 0f, Random.Range(-20, 21)), multiplierSequence.Duration() / 4));
            multiplierSequence.Insert(1, multiplierText.transform.DORotate(Vector3.zero, multiplierSequence.Duration() / 4));
            refreshMultiplier = false;
        }
    }
}
