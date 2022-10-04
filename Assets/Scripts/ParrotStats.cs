using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParrotStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public int decreaseRate = 1;
    //public delegate void OnHealthChanged();
    //public OnHealthChanged onHealthChangedCallback;

    public Image healthBarEmptyness;
    private Animator parrotAnim;

    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject wonScreen;
    [SerializeField] GameObject loseScreen;

    #region Singleton
    public static ParrotStats instance;

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
        //health = maxHealth;
        InvokeRepeating("DecreaseHealth", 10, 1f);

        parrotAnim = GetComponent<Animator>();

        parrotAnim.Play("parrot_fly");
    }
    public void DecreaseHealth()
    {
        health -= decreaseRate;
        if(health <= 0)
        {
            health = 0;
            Die();
        }

        //onHealthChangedCallback?.Invoke();
    }

    public void feed(int foodValue)
    {
        health = Mathf.Min(maxHealth, health + foodValue);
    }

    private void Die()
    {
        Debug.Log("parrot die!!");
        parrotAnim.SetBool("IsParrotDead", true);
        mainUI.SetActive(false);
        loseScreen.SetActive(true);
    }

    public void Win()
    {
        Debug.Log("Won the game!!");
        CancelInvoke();

        mainUI.SetActive(false);
        parrotAnim.Play("parrot_walk");
        wonScreen.SetActive(true);
    }

    public void Bark()
    {
        //parrotAnim.SetBool("IsParrotBarking", true);
        parrotAnim.Play("parrot_bark");
    }

    void Update()
    {
        float healthAmount = health * 1.0f / maxHealth;
        healthBarEmptyness.fillAmount = (1 - healthAmount);

        if(maxHealth - health <= 5)
        {
            Win();
        }
    }
}
