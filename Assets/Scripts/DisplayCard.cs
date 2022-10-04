using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{
    public Card card;
    [SerializeField] Text nameText;
    [SerializeField] Text statsText;
    [SerializeField] Text descriptionText;
    [SerializeField] Text costText;
    //[SerializeField] Text healthText;
    [SerializeField] Image artworkImage;

    [SerializeField] private GameObject darkPanel;
    private Button button;

    private void Start()
    {
        disPlayCard();

        button = GetComponent<Button>();
    }

    public void disPlayCard()
    {
        nameText.text = card.name;
        int value = card.food + card.foodModifier;
        statsText.text = "Health " + (value >= 0 ? "+" : "") + value.ToString();
        descriptionText.text = card.description;

        value = Mathf.Max(card.cost + card.costModifier, 0);
        costText.text = value.ToString();
        artworkImage.sprite = card.artWork;
    }

    public void useCard()
    {
        if(card.useCard())
            Destroy(gameObject);
    }

    private void blackOut()
    {
        darkPanel.SetActive(true);
        button.interactable = false;
    }

    private void lightUp()
    {
        darkPanel.SetActive(false);
        button.interactable = true;
    }

    private void Update()
    {
        if(playerStats.instance.totalMana < Mathf.Max(card.cost + card.costModifier, 0))
        {
            blackOut();
        }
        else
        {
            lightUp();
        }
    }
}
