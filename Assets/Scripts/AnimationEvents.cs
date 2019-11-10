using UnityEngine;
using System.Collections;

public class AnimationEvents : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem particleSystem;

    public void PlayParticleSystem()
    {
        particleSystem.Play();
    }

}
