using UnityEngine;
using UnityEngine.UI;

public class BgColor : MonoBehaviour {

	Color32 white = new Color32 (237, 242, 244, 255);
	Color32 black = new Color32(30, 30, 30, 255);

	Color32 textDark = new Color32(43, 45, 66, 255);

	[SerializeField]
	private Text MultiplierText;
	[SerializeField]
	private Text BonusLiveText;

	public static int activeBgColor;
	void Start () {
		Camera mainCamera = gameObject.GetComponent<Camera> ();
		if (PlayerPrefs.GetInt ("bg_skin_0_active") == 1) {
			activeBgColor = 0;

			mainCamera.backgroundColor = white;
			MultiplierText.color = textDark;
			BonusLiveText.color = textDark;
		} else {
			activeBgColor = 1;

			mainCamera.backgroundColor = black;
			MultiplierText.color = white;
			BonusLiveText.color = white;
		}
	}
}
