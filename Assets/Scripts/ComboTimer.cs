using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ComboTimer : MonoBehaviour {

    [SerializeField]
    private Text timerLabel;
    [SerializeField]
    private float scaleUpSpeed;

    [SerializeField]
    private float initialTime = 7f;
    public static float time;
    public static bool showTimer;
    public static bool animateTimerShow;
    public static bool animateReset;
    public static bool hideTimer;
    private bool hiddenTimer;


    void Start()
    {
        showTimer = false;
        animateTimerShow = false;
        animateReset = false;
        hiddenTimer = true;
    }
    void FixedUpdate()
    {
        if (showTimer)
        {
            if (animateTimerShow)
            {
                AnimateTimerShow();
                time = initialTime;
            }

            if (animateReset)
            {
                AnimateTimerReset();
            }

            time -= Time.deltaTime;

            float seconds = Mathf.Floor(time % 60.0f);
            float fraction = (time * 100) % 100;

            if (seconds < 0 && !hiddenTimer || hideTimer)
            {
                AnimateTimerHide();
            }
            else
            {
                timerLabel.text = string.Format("{0:0}:{1:00}", seconds, fraction);
            }
        }
    }

    void AnimateTimerShow()
    {
        //Sequence timerAppear = DOTween.Sequence();
        //timerAppear.Append(timerLabel.DOFade(255, 0f));
        //timerAppear.Append(timerLabel.transform.DOScale(1.5f, 0.1f));
        //timerAppear.Insert(0, timerLabel.transform.DORotate(new Vector3(0f, 0f, Random.Range(-10, 10)), timerAppear.Duration() / 4));

        if (timerLabel.transform.localScale.x < 1.5f)
        {
            timerLabel.transform.localScale = new Vector3(timerLabel.transform.localScale.x + scaleUpSpeed / 100f, timerLabel.transform.localScale.y + scaleUpSpeed / 100f, timerLabel.transform.localScale.z +  scaleUpSpeed/100f);
            timerLabel.color = new Color(timerLabel.color.r, timerLabel.color.g, timerLabel.color.b, 255);
        }
        else
        {
            animateTimerShow = false;
            hiddenTimer = false;
        }
        
        
    }

    void AnimateTimerHide()
    {
        Sequence timerHide = DOTween.Sequence();
        timerHide.Append(timerLabel.transform.DOScale(1f, 0.1f));
        timerHide.Append(timerLabel.DOFade(0, 0f));
        // timerLabel.color = new Color(timerLabel.color.r, timerLabel.color.g, timerLabel.color.b, 0);
        hiddenTimer = true;
        showTimer = false;
        hideTimer = false;
        Multiplier.refreshMultiplier = true;
        Multiplier.currentMultiplier = 1;
    }

    void AnimateTimerReset()
    {
        Sequence timerReset = DOTween.Sequence();
        timerReset.Append(timerLabel.transform.DOScale(1.15f, 0.05f));
        timerReset.Append(timerLabel.transform.DOScale(1.5f, 0.05f));
        animateReset = false;
    }

}
