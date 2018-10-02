using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{

    //so slowing knows what to set speed back to
    //public float startSpeed = 10f;
    [SerializeField]
    private float startHealth = 100;
    [HideInInspector]
    private float health;
    [SerializeField]
    private int value = 25;
    public GameObject HealthbarCanvas;

    //public GameObject deathEffect;
    [Header("Unity Stuff")]
    [SerializeField]
    private Image healthBar;

    [HideInInspector]
    //public float speed;

    //Unity destroy takes time and could cause problems
    private bool isDead = false;

    void Start()
    {
        //speed = startSpeed;
        health = startHealth;
    }
    private void Update()
    {
        if (health >= startHealth)
        {
            HealthbarCanvas.SetActive(false);
        }
        else
        {
            HealthbarCanvas.SetActive(true);
        }
    }

    public void TakeDamage(float _amount)
    {
        health -= _amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead)
            Die();
    }

    public void Slow(float _percent)
    {
        Debug.LogError("EnemyHP -- Slow: This function is unfinished!");
        //speed = startSpeed * (1 - _percent);
    }

    void Die()
    {
        GameObject.FindWithTag("Base").GetComponent<TownHallScript>().Enemiesleft--;
        isDead = true;

        //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, .5f);
        Debug.Log(gameObject + "has died");
        Destroy(gameObject);
    }
}
