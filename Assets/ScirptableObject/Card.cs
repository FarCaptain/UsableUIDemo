using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    new public string name;

    [TextArea]
    public string stats;
    [TextArea]
    public string description;

    public int cost;
    public int food;
    public int decreaseRateModifier = 0;

    public int costModifier = 0;
    public int foodModifier = 0;

    public Sprite artWork;
    public Sphinx.GameEvent cardEvent;


    private void OnEnable()
    {
        //OnSceneLoaded();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //OnSceneLoaded();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        costModifier = 0;
        foodModifier = 0;
    }

    public bool useCard()
    {
        int realCost = Mathf.Max(cost + costModifier, 0);
        if (playerStats.instance.totalMana >= realCost)
        {
            int realFood = food + foodModifier;
            ParrotStats.instance.feed(realFood);
            ParrotStats.instance.decreaseRate = Mathf.Max(0, ParrotStats.instance.decreaseRate + decreaseRateModifier);
            ParrotStats.instance.Bark();
            playerStats.instance.totalMana -= realCost;

            AudioManager.instance.Play("Food");

            if(cardEvent != null)
            {
                cardEvent.Raise();
            }

            return true;
        }
        return false;
    }

    public void addfoodModifier(int mod)
    {
        foodModifier += mod;
    }
    public void addcostModifier(int mod)
    {
        costModifier += mod;
    }

}
