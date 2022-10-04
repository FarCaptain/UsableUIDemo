using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] GameObject UIPrefab;
    public int handCount;
    public List<Card> cards = new List<Card>();
    public List<float> chances = new List<float>();

    private void Start()
    {
        spawnCard(handCount);
    }

    private void FixedUpdate()
    {
        int currentCardCount = transform.childCount;
        if(currentCardCount < handCount)
        {
            spawnCard(handCount - currentCardCount);
        }
    }

    public void spawnCard(int number)
    {
        for (int i = 0; i < number; i++)
        {
            var cardUI = Instantiate(UIPrefab, transform);
            int index = Random.Range(0, cards.Count);

            var display = cardUI.GetComponent<DisplayCard>();
            display.card = cards[index];
            display.disPlayCard();
        }
    }

    public void clearHand()
    {
        var cards = GetComponentsInChildren<DisplayCard>();
        foreach(var c in cards)
        {
            Destroy(c.gameObject);
        }
    }

    public void updateHandDisplay()
    {
        var cards = GetComponentsInChildren<DisplayCard>();
        foreach(var c in cards)
        {
            c.disPlayCard();
        }
    }
}
