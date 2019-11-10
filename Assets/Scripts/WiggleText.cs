using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;


public class WiggleText : MonoBehaviour {

	private Transform AdText;
	private IEnumerator coroutine;
	// Use this for initialization
	void Start () {
		AdText = gameObject.GetComponent<Transform>();
		AdMovement ();
		coroutine = ShakeAdText(3.0f);
		StartCoroutine (coroutine);
	}
	
	void FixedUpdate () {
		
	}

	private IEnumerator ShakeAdText(float waitTime) {
		while (true)
		{
			yield return new WaitForSeconds(waitTime);
			AdMovement ();
		}
	}

	private void AdMovement() {
		Sequence comboSequence = DOTween.Sequence();
		comboSequence.Append(AdText.transform.DOScale(3f,0.4f));
		comboSequence.Append(AdText.transform.DOScale(1f, 0.4f));
		//comboSequence.Insert(0, AdText.transform.DORotate(new Vector3(0f, 0f, Random.Range(-5, 6)), comboSequence.Duration() / 4));
	}
}
