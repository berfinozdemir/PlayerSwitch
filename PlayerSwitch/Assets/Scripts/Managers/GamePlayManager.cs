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
        //CloseAllAreas();
        //SetDuty();
    }
    public List<UnlockArea> unlockAreas = new List<UnlockArea>();
    public UnlockArea NextArea;
    void CloseAllAreas()
    {
        foreach (var item in unlockAreas)
        {
            item.gameObject.SetActive(false);
        }
    }
    //public UnlockArea SetDuty()
    //{
    //    UnlockArea unlock = null;
    //    for (int i = 0; i < unlockAreas.Count; i++)
    //    {
    //        if (unlockAreas[i].RequiredMetalCount != 0)
    //        {
    //            unlock = unlockAreas[i];
    //            unlock.gameObject.SetActive(true);
    //            NextArea = unlockAreas[i + 1];
    //            break;
    //        }
    //    }
    //    Debug.Log(unlock);
    //    return unlock;
    //}
    
}
