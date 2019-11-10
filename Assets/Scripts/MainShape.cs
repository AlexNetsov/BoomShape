using UnityEngine;
using DG.Tweening;

public class MainShape : MonoBehaviour
{

    public ShapeInside mainShape;

    [SerializeField]
    private GameObject destroyAnimation;

	[SerializeField]
	private GameObject destroyAllShapeAnimation;

    [SerializeField]
    private Transform lowestPoint;

    [SerializeField]
    private Transform MainObjectsSpawnPoint;

    private bool mouseClickedRight;
    private bool isCorrectCombination;
	private bool isAllShapeMatched;

    void Start()
    {
        mouseClickedRight = false;
        isCorrectCombination = false;
    }

    void Update()
    {
		if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1")) && !GameManager.isDead)
        {
            if (isCorrectCombination)
            {
                mouseClickedRight = true;
            }
            else
            {
                PointsAndCombos.currentLives--;
                AudioManager.LiveLost = true;

                //Hide timer
                ComboTimer.hideTimer = true;

                //Reset multiplier
                //Multiplier.refreshMultiplier = true;
                Multiplier.currentMultiplier = 1;

                // Camera Shake
                Camera.main.DOShakePosition(1, new Vector3(.2f, .2f, 0), 20, 90, true);


                if (PointsAndCombos.currentLives < 0)
                {
                    GameManager.isDead = true;
                }
            }
        }


    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.OverlapPoint(lowestPoint.position))
        {
            if (other.GetComponent<OverlayShape>().overlayShapeInside == mainShape)
            {
                isCorrectCombination = true;
            }
			else if (other.GetComponent<OverlayShape>().overlayShapeInside == ShapeInside.all) {
				isCorrectCombination = true;
				isAllShapeMatched = true;
			}
        }
        

        if (isCorrectCombination && mouseClickedRight)
        {
            //Reset vars
            mouseClickedRight = false;
            isCorrectCombination = false;

            //Show added score
            PointsAndCombos.showComboText = true;

            //Show combo timer or reset the one active if there is such
            if (ComboTimer.showTimer)
            {
                ComboTimer.time += 3f;
                ComboTimer.animateReset = true;
                Multiplier.refreshMultiplier = true;
                Multiplier.currentMultiplier++;
                if (Multiplier.currentMultiplier % 7 == 0)
                {
                    PointsAndCombos.currentLives++;
                }
            }
            else
            {
                ComboTimer.showTimer = true;
                ComboTimer.animateTimerShow = true;
            }

            
            //Update Score
            PointsAndCombos.playerScore += 100 * Multiplier.currentMultiplier;

            //Audio
            AudioManager.ShapeDestroyed = true;

			//Explosion
			if (isAllShapeMatched) {
				GameObject animGO = (GameObject)Instantiate (destroyAllShapeAnimation, transform.position, Quaternion.identity);
				ParticleSystem anim = animGO.GetComponent<ParticleSystem> ();
				anim.Play ();
				Destroy (animGO, 1f);
			} 
			else {
				GameObject animGO = (GameObject)Instantiate(destroyAnimation, transform.position, Quaternion.identity);
				ParticleSystem anim = animGO.GetComponent<ParticleSystem>();
				anim.Play();
				Destroy(animGO, 1f);
			}
			isAllShapeMatched = false;
            
            //Destruction
            Destroy(gameObject);
            Destroy(other.gameObject);

            //Camera Shake
            Camera.main.DOShakePosition(1, new Vector3(.3f, .3f, 0), 10, 50, true);

            //Spawn new shape
            Instantiate(MainShapePrefabs.Instance.MainShapesPrefabs[Random.Range(0, MainShapePrefabs.Instance.MainShapesPrefabs.Length)], MainObjectsSpawnPoint.position, Quaternion.identity);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isCorrectCombination = false;
        mouseClickedRight = false;
    }
}
