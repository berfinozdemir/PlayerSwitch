using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stash : MonoBehaviour
{
    public Transform FirstStashPoint;
    public int ZAmount, YAmount, XAmount;
    public float space;
    public List<Vector3> StashPosList = new List<Vector3>();
    public int maxCollectableCount = 5;
    public int CollectedCount => CollectedObjects.Count;
    public List<Stashable> CollectedObjects = new List<Stashable>();
    public Transform StashParent;

    private void Start()
    {
        CreateStashPositions();
    }
    public void CreateStashPositions()
    {
        Vector3 pos = Vector3.zero;
        for (int h = 0; h < ZAmount; h++)
        {
            for (int i = 0; i < XAmount; i++)
            {
                for (int j = 0; j < YAmount; j++)
                {
                    pos = Vector3.zero + Vector3.up * space * j + Vector3.right * space * i + Vector3.back * space * h;
                    StashPosList.Add(pos);
                }
            }
        }
    }
    private int index = 0;
    public Vector3 GetStashPosition()
    {
        var newPos = StashPosList[index];
        index++;
        return newPos;
    }

    public void AddStash(Collectable collected)
    {
        if (CollectedCount >= maxCollectableCount)
            return;

        var yLocalPosition = CollectedCount * 1;

        var stashable = collected.Collect();
        stashable.CollectStashable(StashParent, yLocalPosition, GetStashPosition(), CollectionComplete);
        CollectedObjects.Add(stashable);

    }
    public Stashable RemoveStash()
    {
        if (CollectedCount <= 0)
            return null;

        var stashable = CollectedObjects[CollectedCount - 1];
        CollectedObjects.Remove(stashable);
        stashable.transform.parent = null;
        index--;//bura bak
        return stashable;
    }
    public void CollectionComplete()
    {
        UIManager.Instance.UpdateResourceText(CollectedObjects.Count);
    }
}

