using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        SetDuty();
    }
    public List<UnlockArea> unlockAreas = new List<UnlockArea>();
    public UnlockArea SetDuty()
    {
        UnlockArea unlock = null;
        foreach (var item in unlockAreas)
        {
            if (item.RequiredMetalCount != 0)
            {
                unlock = item;
                break;
            }
        }
        Debug.Log(unlock);
        return unlock;
    }
    
}
