using UnityEngine;


namespace Phyw
{
  public class ArrowCollision : MonoBehaviour
  {

    #region Variables
    [SerializeField] GameObject noCollisionArrow;
    #endregion

    #region UnityMethods

    private void Start()
    {
      Destroy(gameObject, 15);
    }

    private void OnCollisionEnter(Collision collision)
    {
      //GameObject arr = Instantiate(noCollisionArrow, transform.position, transform.rotation);

      if (collision.collider != null)
      {
        print($"{collision.collider.name} {collision.collider.tag}");
        if (collision.collider.TryGetComponent(out HealthController healther))
        {
          healther.TakeDamage(30);
        }

      }

      Destroy(gameObject);
      //Destroy(arr, 5);

    }

    #endregion

    #region CustomMethods

    #endregion
  }
}