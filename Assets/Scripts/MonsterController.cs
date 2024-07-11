using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterController : MonoBehaviour
{
    [SerializeField] string monsterName = "";
    int maxHealth = 100;
    [SerializeField] int health = 100;
    [SerializeField] float speed = 5f; // Adjust this value to control the speed of movement
    [SerializeField] int damage;
    [SerializeField] float evasion;
    [SerializeField] int resilience;
    
    [SerializeField] GameObject sliderCanvasPrefab;
    [SerializeField] Slider slider;
    private Rigidbody2D rb;

    GameObject enemyPlayer;

    public void InitializeMonster(PlayerMonster thisMonster)
    {
        SetStartValues(thisMonster);
        StartActions();
    }

    void SetStartValues(PlayerMonster thisMonster)
    {
        Instantiate(sliderCanvasPrefab, transform.position, Quaternion.identity, this.transform);
        enemyPlayer = GameObject.Find("EnemyPlayer");
        slider = GetComponentInChildren<Slider>();
        rb = GetComponent<Rigidbody2D>();

        monsterName = thisMonster.monsterName;
        maxHealth = thisMonster.health;
        health = maxHealth;
        slider.value = 1;
        speed = thisMonster.speed / 10f;
        damage = thisMonster.damage;
        evasion = thisMonster.evasion;
        resilience = thisMonster.resilience;
    }

    void StartActions()
    {
        MoveTowardsEnemyPlayer();
    }

    private void Update()
    {
        MoveTowardsEnemyPlayer();
    }

    void MoveTowardsEnemyPlayer()
    {
        if (enemyPlayer != null)
        {
            Vector2 direction = (enemyPlayer.transform.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
            Destroy(this.gameObject);

        slider.value = Tools.instance.NormalizeToSlider(health, maxHealth);
    }
}
