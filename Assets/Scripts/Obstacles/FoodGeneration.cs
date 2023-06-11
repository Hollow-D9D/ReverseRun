using UnityEngine;

public class FoodGeneration : MonoBehaviour {
    [SerializeField] private float leftEdge;
    [SerializeField] private float rightEdge;
    [SerializeField] private float startZValue = -15f;
    [SerializeField] private float endZValue;
    [SerializeField] private float spawnYValue;

    [SerializeField] private int foodCount = 1;

    private GameObject[] FoodPrefabs;
    private float foodInterval;

    private void Awake() {
        LoadObstacles();
    }

    
    private void Start() {
        InputManager.Instance.OnGameStart += GenerateFood;
        
    }
    private void GenerateFood()
    {
        endZValue = LocalDB.Instance.db.data.ropeValue;
        foodCount = -(int)(endZValue / 20);
        CalcucalteFoofInterval();

        for (int i = 0; i < foodCount; i++)
        {
            if (startZValue <= endZValue)
                return;

            Instantiate(FoodPrefabs[Random.Range(0, FoodPrefabs.Length)], ReturnRandomSpawnPos(), Quaternion.identity);
        }
    }
    private void OnDestroy() => InputManager.Instance.OnGameStart -= GenerateFood;
    private Vector3 ReturnRandomSpawnPos() =>
         new Vector3(Random.Range(leftEdge,rightEdge),spawnYValue,InitZValue(ref startZValue));

    private void LoadObstacles() {
        FoodPrefabs = Resources.LoadAll<GameObject>("Obstacles/Food");
    }

    private void CalcucalteFoofInterval() {
        foodInterval = (endZValue - startZValue) / foodCount;
    }

    private float InitZValue(ref float startZValue) {
        float zValue = Random.Range(startZValue,startZValue + foodInterval);
        startZValue += foodInterval;
        startZValue += Random.Range(-3, 3);
        return zValue;
    }

}

