using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public TextMeshProUGUI resourceTxt;
    public void UpdateResourceText(int resourceCount)
    {
        resourceTxt.text = resourceCount.ToString();
    }
}
