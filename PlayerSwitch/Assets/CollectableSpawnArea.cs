using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableSpawnArea : MonoBehaviour
{
    public List<Vector3> spawnPoints;
    public int XSize;
    public int YSize;
    public int MaxSpawnCount;
    public float xspace, yspace;
    public GameObject collectablePrefab;
    public List<GameObject> SpawnedCollectables = new List<GameObject>();
    [SerializeField] private int _maxSpawnCount = 10;
    [SerializeField] private float _spawnRadius = 10;

    [SerializeField] private float _spawnPeriod = 2f;
    List<int> selectedPos;

    private float nextSpawnTime = 0;
    //public float yspace;
    private void Awake()
    {
        CreateSpawnPoints();
    }
    private void Start()
    {
    }
    private void Update()
    {
        HandleNullElements();
        if (SpawnedCollectables.Count >= MaxSpawnCount)
        {
            return;
        }

        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + _spawnPeriod;
            Spawn();
        }
    }
    public void CreateSpawnPoints()
    {
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < XSize; i++)
        {
            for (int j = 0; j < YSize; j++)
            {
                pos = transform.position + Vector3.right * xspace * i + Vector3.forward * j * yspace;

                spawnPoints.Add(pos);
            }
        }
    }
    public void Spawn()
    {
        var collectable = Instantiate(collectablePrefab, null);
        collectable.transform.position = spawnPoints[UniqueRandomInt()];//list shuffle ile yapýlabilir
        SpawnedCollectables.Add(collectable);
        collectable.transform.localScale = Vector3.zero;
        collectable.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack, 2.5f);
        collectable.transform.DORotate(Vector3.up * 360f, 5f, RotateMode.LocalAxisAdd).SetLoops(-1);

    }
    public void OpenObject(GameObject collectable)
    {

    }
    //    int index=0;
    //public int SelectRandomIndex()
    //{
    //    index = Random.Range(0, spawnPoints.Count - 1);
    //    if (!selectedPos.Contains(index))
    //    {

    //    }
    //        selectedPos.Add(index);
    //    // Debug.Log(index);
    //    //spawnPoints.RemoveAt(index);
        
    //    return index;
    //}
    private void HandleNullElements()
    {
        for (int i = SpawnedCollectables.Count - 1; i >= 0; i--)
        {
            if (SpawnedCollectables[i] == null)
            {
                SpawnedCollectables.RemoveAt(i);
            }
        }

    }
    public List<int> randomList = new List<int>();
    int UniqueRandomInt()
    {
        //var rand = new Random();
        int myNumber;
        do
        {
            myNumber = Random.Range(0, spawnPoints.Count-1);//bu dongu tehlikeli!!!
        } while (randomList.Contains(myNumber));

        randomList.Add(myNumber);
        return myNumber;
    }
}
