using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockArea : MonoBehaviour
{
    //public int RequiredMetalCount;
    //public GameObject UnlockedObject;
    //public GameObject UnlockedCanvas;
    //private void Start()
    //{
    //    //UnlockedObject.gameObject.SetActive(false);
    //    SetRequirement();
    //}

    //void SetRequirement()
    //{
    //    //RequiredMetalCount = UnlockedObject.GetComponent<Player>();
    //}
    private const string UNLOCK_PLAYERPREF_KEY = "UNLOCK_PLAYERPREF_KEY:";
    public string UnlockableName;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI PriceText;
    public List<GameObject> ObjectsToUnlock = new List<GameObject>();

 
    public int RequiredPrice = 20;

    public int RemainingPrice => RequiredPrice - CollectedPrice;

    public int CollectedPrice
    {
        get => PlayerPrefs.GetInt(UNLOCK_PLAYERPREF_KEY + UnlockableName, 0);
        set => PlayerPrefs.SetInt(UNLOCK_PLAYERPREF_KEY + UnlockableName, value); 
    }

    private void OnEnable()
    {
        CheckUnlocked();
    }

    // Start is called before the first frame update
    void Start()
    { 
        ObjectsToUnlock.ForEach((x) => x.SetActive(false));
        //ObjectToUnlock.SetActive(false);
        NameText.text = UnlockableName;
        PriceText.text = RemainingPrice.ToString();  
    }

    public void Pay(Stashable stashable)
    {
        if (RemainingPrice <= 0)
            return;

        CollectedPrice++;
        stashable.PayStashable(transform, PaymentCompleted);
         
    }

    private void PaymentCompleted()
    {
        PriceText.text = RemainingPrice.ToString();

        CheckUnlocked();
    }

    private void CheckUnlocked()
    {
        if (RemainingPrice <= 0)
        {
            ObjectsToUnlock.ForEach((x) =>
            {
                x.transform.parent = null;
                x.SetActive(true);
            });

            gameObject.SetActive(false);
        }
    }
}
