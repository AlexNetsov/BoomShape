using UnityEngine;
using UnityEngine.UI;

public class OverlaySpawner : MonoBehaviour
{



    [SerializeField]
    private Transform[] OverlayShapesSpawnPoint;
    [SerializeField]
    private GameObject FitAllOverlayShapePrefab;
    [SerializeField]
    private GameObject[] CircleOverlayShapesPrefabs;
    [SerializeField]
    private GameObject[] SquareOverlayShapesPrefabs;
    [SerializeField]
    private GameObject[] TriangleOverlayShapesPrefabs;
    [System.Serializable]
    public class TextureList
    {
        public Sprite[] textures;
    }
    public TextureList[] AlpineTextures = new TextureList[3];
    public TextureList[] InspirationTextures = new TextureList[3];
    public TextureList[] TessalationTextures = new TextureList[3];
    public TextureList[] TribalNordicTextures = new TextureList[3];
    public TextureList[] VibranceTextures = new TextureList[3];
    public TextureList[] TrianglesTextures = new TextureList[3];
    public TextureList[] Triangles2Textures = new TextureList[3];
    public TextureList[] Triangles3Textures = new TextureList[3];
    public TextureList[] TurkishTrianglesTextures = new TextureList[3];

    [SerializeField]
    private int changeTexturePoints;

    private ShapeInside currentMainShape;

    private bool shouldSpawnOverlay = false;
    private float timeToSpawn = 0f;
    [SerializeField]
    private float initialSpawnInterval = 2f;
    [SerializeField]
    private float spawnConstant = 0.05f;
    private GameObject OverlayShapeGO;


    void Start()
    {
        Invoke("SpawnOverlayShapes", 1f);
    }

    void FixedUpdate()
    {
        timeToSpawn += Time.deltaTime;
        if (timeToSpawn >= initialSpawnInterval && initialSpawnInterval > 0.3f)
        {
            SpawnOverlayShapes();
            timeToSpawn = 0;
            initialSpawnInterval -= spawnConstant;
        }
    }

    void SpawnOverlayShapes()
    {
        currentMainShape = GameObject.FindGameObjectWithTag("mainshape").GetComponent<MainShape>().mainShape;

        int index = Random.Range(0, 10);
        if (index < 6)
        {
            SpawnSameShape();
        }
        else if (index == 8)
        {
            SpawnAllShape();
        }
        else
        {
            int r = Random.Range(0, 2);
            SpawnOtherShape(r);
        }
    }

    void SpawnSameShape()
    {
        switch (currentMainShape)
        {
            case ShapeInside.square:
                 OverlayShapeGO = (GameObject)Instantiate(SquareOverlayShapesPrefabs[Random.Range(0, SquareOverlayShapesPrefabs.Length)], OverlayShapesSpawnPoint[Random.Range(0, OverlayShapesSpawnPoint.Length)].position, Quaternion.identity);
                ChangeTexture(OverlayShapeGO);
                break;
            case ShapeInside.circle:
                 OverlayShapeGO = (GameObject)Instantiate(CircleOverlayShapesPrefabs[Random.Range(0, CircleOverlayShapesPrefabs.Length)], OverlayShapesSpawnPoint[Random.Range(0, OverlayShapesSpawnPoint.Length)].position, Quaternion.identity);
                ChangeTexture(OverlayShapeGO);
                break;
            case ShapeInside.triangle:
                 OverlayShapeGO = (GameObject)Instantiate(TriangleOverlayShapesPrefabs[Random.Range(0, TriangleOverlayShapesPrefabs.Length)], OverlayShapesSpawnPoint[Random.Range(0, OverlayShapesSpawnPoint.Length)].position, Quaternion.identity);
                ChangeTexture(OverlayShapeGO);
                break;
            default:
                break;
        }
    }

    void SpawnOtherShape(int r)
    {
        switch (currentMainShape)
        {
            case ShapeInside.square:
                if (r == 1)
                {
                    OverlayShapeGO = (GameObject)Instantiate(CircleOverlayShapesPrefabs[Random.Range(0, CircleOverlayShapesPrefabs.Length)], OverlayShapesSpawnPoint[Random.Range(0, OverlayShapesSpawnPoint.Length)].position, Quaternion.identity);
                    ChangeTexture(OverlayShapeGO);
                }
                else
                {
                    OverlayShapeGO = (GameObject)Instantiate(TriangleOverlayShapesPrefabs[Random.Range(0, TriangleOverlayShapesPrefabs.Length)], OverlayShapesSpawnPoint[Random.Range(0, OverlayShapesSpawnPoint.Length)].position, Quaternion.identity);
                    ChangeTexture(OverlayShapeGO);
                }
                break;
            case ShapeInside.circle:
                if (r == 1)
                {
                    OverlayShapeGO = (GameObject)Instantiate(SquareOverlayShapesPrefabs[Random.Range(0, SquareOverlayShapesPrefabs.Length)], OverlayShapesSpawnPoint[Random.Range(0, OverlayShapesSpawnPoint.Length)].position, Quaternion.identity);
                    ChangeTexture(OverlayShapeGO);
                }
                else
                {
                    OverlayShapeGO = (GameObject)Instantiate(TriangleOverlayShapesPrefabs[Random.Range(0, TriangleOverlayShapesPrefabs.Length)], OverlayShapesSpawnPoint[Random.Range(0, OverlayShapesSpawnPoint.Length)].position, Quaternion.identity);
                    ChangeTexture(OverlayShapeGO);
                }
                break;
            case ShapeInside.triangle:
                if (r == 1)
                {
                    OverlayShapeGO = (GameObject)Instantiate(CircleOverlayShapesPrefabs[Random.Range(0, CircleOverlayShapesPrefabs.Length)], OverlayShapesSpawnPoint[Random.Range(0, OverlayShapesSpawnPoint.Length)].position, Quaternion.identity);
                    ChangeTexture(OverlayShapeGO);
                }
                else
                {
                    OverlayShapeGO = (GameObject)Instantiate(SquareOverlayShapesPrefabs[Random.Range(0, SquareOverlayShapesPrefabs.Length)], OverlayShapesSpawnPoint[Random.Range(0, OverlayShapesSpawnPoint.Length)].position, Quaternion.identity);
                    ChangeTexture(OverlayShapeGO);
                }
                break;
            default:
                break;
        }
    }

    void SpawnAllShape()
    {
        OverlayShapeGO = (GameObject)Instantiate(FitAllOverlayShapePrefab, OverlayShapesSpawnPoint[Random.Range(0, OverlayShapesSpawnPoint.Length)].position, Quaternion.identity);
    }

    void ChangeTexture(GameObject overlayShape)
    {
        int numberOfSkin = PointsAndCombos.playerScore / changeTexturePoints;
        ShapeInside overlayShapeInside= overlayShape.GetComponent<OverlayShape>().overlayShapeInside;
        SpriteRenderer OverlaySR = OverlayShapeGO.GetComponent<SpriteRenderer>();
        int numberOfShapeInside = 0;

        switch (overlayShapeInside)
        {
            case ShapeInside.circle:
                numberOfShapeInside = 0;
                break;
            case ShapeInside.square:
                numberOfShapeInside = 1;
                break;
            case ShapeInside.triangle:
                numberOfShapeInside = 2;
                break;
            default:
                break;
        }

		if (BgColor.activeBgColor == 1 || PointsAndCombos.playerScore > changeTexturePoints) {
			OverlaySR.color = new Color32 (237, 242, 244, 255);
		}

        switch (numberOfSkin)
        {
			case 0:
				break;
			case 1:
                OverlaySR.sprite = AlpineTextures[numberOfShapeInside].textures[Random.Range(0,2)];
                break;
            case 2:
                OverlaySR.sprite = InspirationTextures[numberOfShapeInside].textures[Random.Range(0, 2)];
                break;
            case 3:
                OverlaySR.sprite = TessalationTextures[numberOfShapeInside].textures[Random.Range(0, 2)];
                break;
            case 4:
                OverlaySR.sprite = TribalNordicTextures[numberOfShapeInside].textures[Random.Range(0, 2)];
                break;
            case 5:
                OverlaySR.sprite = VibranceTextures[numberOfShapeInside].textures[Random.Range(0, 2)];
                break;
            case 6:
                OverlaySR.sprite = TrianglesTextures[numberOfShapeInside].textures[Random.Range(0, 2)];
                break;
            case 7:
                OverlaySR.sprite = Triangles2Textures[numberOfShapeInside].textures[Random.Range(0, 2)];
                break;
            case 8:
                OverlaySR.sprite = Triangles3Textures[numberOfShapeInside].textures[Random.Range(0, 2)];
                break;
            case 9:
                OverlaySR.sprite = TurkishTrianglesTextures[numberOfShapeInside].textures[Random.Range(0, 2)];
                break;
            default:
				OverlaySR.sprite = TurkishTrianglesTextures[numberOfShapeInside].textures[Random.Range(0, 2)];
                break;
        }
    }
}