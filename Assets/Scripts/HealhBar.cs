using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform healthBar; // Ссылка на Transform полоски здоровья
    private float initialScaleX; // Начальный размер по X
    private Vector3 initialPosition; // Начальная позиция

    void Start()
    {
        if (healthBar != null)
        {
            initialScaleX = healthBar.localScale.x;
            initialPosition = healthBar.localPosition;
        }
    }

    // Метод для обновления полоски здоровья
    public void UpdateHealthBar(float healthPercentage)
    {
        if (healthBar != null)
        {
            Vector3 scale = healthBar.localScale;
            scale.x = initialScaleX * healthPercentage;
            healthBar.localScale = scale;

            Vector3 position = healthBar.localPosition;
            position.x = initialPosition.x - (initialScaleX - scale.x) / 2;
            healthBar.localPosition = position;
        }
    }
}
