using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public const float MAXHEALTH = 100;

    [SerializeField]
    private float currentHealth;

    public float _currentHealth
    {
        get { return currentHealth; }
        private set { currentHealth = value; }
    }

    [SerializeField]
    private bool dead;

    public bool _dead
    {
        get { return dead; }
        private set { dead = value; }
    }

    // Use this for initialization
    void Start () {
        _currentHealth = MAXHEALTH;
        _dead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (_currentHealth <= 0)
        {
            _dead = true;
        }
            
	}

    public void TakeDmg(float amount)
    {
        if (_currentHealth - amount < 0)
            _currentHealth -= amount;
        else _currentHealth = 0;
    }
    public void Heal(float amount)
    {
        if (_currentHealth + amount < MAXHEALTH)
            _currentHealth += amount;
        else _currentHealth = MAXHEALTH;
    }
}
