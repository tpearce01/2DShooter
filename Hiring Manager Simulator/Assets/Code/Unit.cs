using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image healthBarFill;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        UpdateHealthBar();
    }

    public void ModifyHealth(int value)
    {
        currentHealth += value;
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    protected virtual void Kill()
    {
        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;
            if (healthBar.value/healthBar.maxValue < .5)
            {
                Color temp = Color.Lerp(Color.red, Color.yellow, healthBar.value/(healthBar.maxValue/2));
                healthBarFill.GetComponent<Image>().color = temp;
            }
            else
            {
                Color temp = Color.Lerp(Color.yellow, Color.green,
                    (healthBar.value - (healthBar.maxValue/2))/(healthBar.maxValue/2));
                healthBarFill.color = temp;
            }
        }
    }
}
