using UnityEngine;

public enum ShapeInside
{
    square, circle, triangle, all
}

public class OverlayShape : MonoBehaviour
{
    public ShapeInside overlayShapeInside;

    [SerializeField]
    private float fallSpeed = 1f;

    private CircleCollider2D coll;
    private Vector2 dir;

    void Start()
    {
        coll = gameObject.GetComponent<CircleCollider2D>();
        Vector2 heading = Vector2.zero - (Vector2)gameObject.transform.position;
        float distance = heading.magnitude;
        dir = heading / distance;
    }

    void FixedUpdate()
    {

        gameObject.transform.Translate(dir * OverlaysMovement.currentMoveSpeed * Time.deltaTime, Space.World);
		if (PointsAndCombos.playerScore > 1000) {
			gameObject.transform.Rotate(new Vector3 (0f, 0f, PointsAndCombos.playerScore / 1000f));	
		}
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}