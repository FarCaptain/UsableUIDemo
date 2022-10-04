using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour
{
    public int totalMana;
    public Text manaText;

    #region Singleton
    public static playerStats instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(this);
        }
    }
    #endregion

    private void Start()
    {
        totalMana = 0;
    }

    private void Update()
    {
        manaText.text = totalMana.ToString();
    }
}
