using UnityEngine;

public class MainShapePrefabs : MonoBehaviour
{
    public GameObject[] MainShapesPrefabs;

    private static MainShapePrefabs m_Instance = null;

    public static MainShapePrefabs Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (MainShapePrefabs)FindObjectOfType(typeof(MainShapePrefabs));
            }
            return m_Instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
