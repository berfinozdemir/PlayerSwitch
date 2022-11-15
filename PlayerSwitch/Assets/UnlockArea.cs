using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockArea : MonoBehaviour
{
    public int RequiredMetalCount;
    public GameObject UnlockedObject;
    public GameObject UnlockedCanvas;
    private void Start()
    {
        //UnlockedObject.gameObject.SetActive(false);
        SetRequirement();
    }

    void SetRequirement()
    {
        //RequiredMetalCount = UnlockedObject.GetComponent<Player>();
    }
}
