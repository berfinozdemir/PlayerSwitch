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

    [SerializeField] private float _spawnPeriod = 2f;
    private float nextSpawnTime = 0;
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
        var index = Random.Range(0,spawnPoints.Count-1);
        collectable.transform.position = spawnPoints[index];//list shuffle ile yapýlabilir
        //Debug.Log(spawnPoints[index] + " + " + index);
        spawnPoints.RemoveAt(index);
        SpawnedCollectables.Add(collectable);
        collectable.transform.localScale = Vector3.zero;
        collectable.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack, 2.5f);
        collectable.transform.DORotate(Vector3.up * 360f, 5f, RotateMode.LocalAxisAdd).SetLoops(-1);

    }
    public void Collect()
    {
        // eger metal toplanýrsa pozisyonu tekrar listeye ekle 
    }
  
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
    //List<int> randomList = new List<int>();
    //int UniqueRandomInt()
    //{
    //    //var rand = new Random();
    //    int index;
    //    do
    //    {
    //        index = Random.Range(0, spawnPoints.Count-1);//bu dongu tehlikeli!!!
    //    } while (randomList.Contains(index));

    //    randomList.Add(index);
    //    return index;
    //}
    
}
