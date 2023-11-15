using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Phyw
{
  public class HealthController : MonoBehaviour
  {

    #region Variables

    [SerializeField] private float maxHealth = 600;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private UnityEvent<float> OnTakeDamage;
    private float health;
    #endregion

    #region UnityMethods

    void Start()
    {
      health = maxHealth;
      TakeDamage(0);
    }

    #endregion

    #region CustomMethods

    [ContextMenu("Damage")]
    public void Dam()
    {
      TakeDamage(30);
    }

    public void TakeDamage(int damage)
    {
      health -= damage;
      float currentHealth = health / maxHealth;
      OnTakeDamage.Invoke(currentHealth);

      if (healthSlider != null)
        healthSlider.value = currentHealth;
      if (health <= 0)
      {
        print("Dead " + gameObject.name);
        //Destroy(gameObject);

      }
    }

    #endregion
  }
}