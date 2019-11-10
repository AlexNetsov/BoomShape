using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public static bool ShapeDestroyed = false;
    public static bool LiveLost = false;

    private bool hasSounds = true;

    [SerializeField]
    private AudioClip[] DestroySounds;

    [SerializeField]
    private AudioClip LoseLiveSound;

	void Start () {
		if (PlayerPrefs.GetInt("music_volume", 1) == 0)
		{
			gameObject.GetComponent<AudioSource>().volume = 0;
		}        

        if (PlayerPrefs.GetInt("sounds_volume", 1) == 0)
        {
            hasSounds = false;
        }
	}
	
	void Update () {
        if (hasSounds)
        {
            if (ShapeDestroyed)
            {
                AudioSource.PlayClipAtPoint(DestroySounds[Random.Range(0, DestroySounds.Length)], Vector3.zero, 100f);
                ShapeDestroyed = false;
            }
            if (LiveLost)
            {
                AudioSource.PlayClipAtPoint(LoseLiveSound, Vector3.zero, 100f);
                LiveLost = false;
            }
        }       
	}
}
