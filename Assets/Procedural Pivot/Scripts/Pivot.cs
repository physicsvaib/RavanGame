using UnityEngine;
using UnityEngine.Events;

namespace Phyw
{
  public class Pivot : MonoBehaviour
  {

    #region Variables

    [SerializeField] Transform pivot;
    [SerializeField] UnityEvent onLocationChange;

    #endregion

    #region UnityMethods

    void Update()
    {
      HandleMovement();
    }

    private void HandleMovement()
    {
      float hori = Input.GetAxisRaw("Horizontal");
      float vert = Input.GetAxisRaw("Vertical");

      if (hori != 0 || vert != 0)
      {
        pivot.Translate(new Vector3(hori, vert) * Time.deltaTime);
        onLocationChange.Invoke();
      }
    }

    #endregion

    #region CustomMethods

    #endregion
  }
}