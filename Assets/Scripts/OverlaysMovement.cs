using UnityEngine;
using System.Collections;

public class OverlaysMovement : MonoBehaviour {

    [Header("Speed")]
    [SerializeField]
    private float initialMoveSpeed = 1f;
    [SerializeField]
    private float maxMoveSpeed = 4f;
    [SerializeField]
    private float increaseRate = 300f;
    public static float currentMoveSpeed;
    // Use this for initialization
    void Start () {
        currentMoveSpeed = initialMoveSpeed;
    }

    void FixedUpdate()
    {
        MoveOverlayObjects();
    }

    void MoveOverlayObjects()
    {
        if (currentMoveSpeed < maxMoveSpeed)
        {
            currentMoveSpeed += Time.deltaTime / increaseRate;
        }
    }
}
