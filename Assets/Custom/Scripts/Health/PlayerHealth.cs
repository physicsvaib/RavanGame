using UnityEngine;


namespace Phyw
{
  public class PlayerHealth : MonoBehaviour
  {

    #region Variables

    #endregion

    #region UnityMethods

    void Start()
    {

    }

    void Update()
    {

    }
    #endregion

    #region CustomMethods
    public void HealthChange(float f)
    {
      if (f < .2f)
      {
        print("In Danger");
      }
      if (f < 0)
      {
        print("Done for");
      }
    }
    #endregion
  }
}