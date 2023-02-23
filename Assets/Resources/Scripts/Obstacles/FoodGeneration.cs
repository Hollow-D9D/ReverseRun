using UnityEngine;

public class FoodGeneration : MonoBehaviour {
    [SerializeField] private float leftEdge;
    [SerializeField] private float rightEdge;
    [SerializeField] private float startZValue = -15f;
    [SerializeField] private float endZValue = -155f;
    [SerializeField] private float spawnYValue;

    [SerializeField] private int foodCount = 4;

    private GameObject[] FoodPrefabs;
    private float foodInterval;

    private void Awake() {
        LoadObstacles();

        CalcucalteFoofInterval();
    }

    private void Start() {

        for(int i = 0;i < foodCount;i++) {
            if(startZValue <= endZValue)
                return;

            Instantiate(FoodPrefabs[Random.Range(0,FoodPrefabs.Length)],ReturnRandomSpawnPos(),Quaternion.identity);
        }
    }

    private Vector3 ReturnRandomSpawnPos() =>
         new Vector3(Random.Range(leftEdge,rightEdge),spawnYValue,InitZValue(ref startZValue));

    private void LoadObstacles() {
        FoodPrefabs = Resources.LoadAll<GameObject>("Prefabs/Obstacles/Food");
    }

    private void CalcucalteFoofInterval() {
        foodInterval = (endZValue - startZValue) / foodCount;
    }

    private float InitZValue(ref float startZValue) {
        float zValue = Random.Range(startZValue,startZValue + foodInterval);
        startZValue += foodInterval;

        return zValue;
    }

}

