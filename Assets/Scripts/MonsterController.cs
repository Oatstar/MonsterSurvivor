using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterController : MonoBehaviour
{
    [SerializeField] int health = 100;
    int maxHealth = 100;
    [SerializeField] float speed = 5f; // Adjust this value to control the speed of movement
    [SerializeField] GameObject sliderCanvasPrefab;
    [SerializeField] Slider slider;
    private Rigidbody2D rb;
    
    void Start()
    {
        Instantiate(sliderCanvasPrefab, transform.position, Quaternion.identity, this.transform);
        slider = GetComponentInChildren<Slider>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, rb.velocity.y); // Initial velocity towards right
    }

    public void DealDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
            Destroy(this.gameObject);

        slider.value = Tools.instance.NormalizeToSlider(health, maxHealth);
    }
}
