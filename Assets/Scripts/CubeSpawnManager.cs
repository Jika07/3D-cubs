using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab = default;
    [SerializeField] private Transform cubesTransform = default;
    [SerializeField] private InputField inputTime, inputSpeed, inputDistance;

    private GameObject[] cubePool = new GameObject[10];
    private bool isUIInputsSet = false;
    private float timeInterval = 0;
    private float cubeSpeed = 0;
    private float distance = 0;
    private float timePassed = 0;

    private void Awake()
    {
        inputTime.onEndEdit.AddListener((value) => float.TryParse(value, out timeInterval));
        inputSpeed.onEndEdit.AddListener((value) => float.TryParse(value, out cubeSpeed));
        inputDistance.onEndEdit.AddListener((value) => float.TryParse(value, out distance));

        InitializePool();
    }

    private void Update()
    {
        isUIInputsSet = timeInterval > 0 && cubeSpeed > 0 && distance > 0;

        if (isUIInputsSet)
        {
            if (timePassed == 0)
            {
                timePassed = timeInterval;
                SpawnCube();
            }

            timePassed -= Time.deltaTime;
            if (timePassed < 0)
            {
                timePassed = 0;
            }
        }
    }

    private void InitializePool()
    {
        for (int i = 0; i < cubePool.Length; i++)
        {
            GameObject cubeObjet = Instantiate(cubePrefab, cubesTransform);
            cubeObjet.name = $"Cube{i}";
            cubeObjet.SetActive(false);
            cubePool[i] = cubeObjet;
        }
    }

    private void SpawnCube()
    {
        for (int i = 0; i < cubePool.Length; i++)
        {
            GameObject cubeObject = cubePool[i];
            if (!cubeObject.activeSelf)
            {
                cubeObject.SetActive(true);
                CubeItem cubeItem = cubeObject.GetComponent<CubeItem>();
                cubeItem.moveSpeed = cubeSpeed;
                cubeItem.distanceToPass = distance;
                break;
            }
        }
    }

}
