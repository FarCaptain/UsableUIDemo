using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    [SerializeField] private List<Sprite> diceSprites = new List<Sprite>();
    [SerializeField] private Image diceFace;

    private int numberOfRolling = 13;
    private Button diceButton;

    public int currentDiceIndex = 0;

    private void Start()
    {
        diceButton = GetComponent<Button>();
    }

    public void RollDice()
    {
        StartCoroutine(ShowDiceRoll());
    }

    private IEnumerator ShowDiceRoll()
    {
        diceButton.interactable = false;
        float st = 0.05f, ed = 0.3f;
        float pace = (ed - st) / numberOfRolling;
        for (float i = st; i < ed; i += pace)
        {
            currentDiceIndex = Random.Range(0, 6);
            diceFace.sprite = diceSprites[currentDiceIndex];
            yield return new WaitForSeconds(i);
        }
        diceButton.interactable = true;

        int currentDiceValue = currentDiceIndex + 1;
        playerStats.instance.totalMana = currentDiceValue;
    }
}
