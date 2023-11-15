using System.Collections;
using UnityEngine;


namespace Phyw
{
  public class RavanBehavior : MonoBehaviour
  {


    #region Variables
    bool shouldStart;
    #endregion


    #region UnityMethods

    void Start()
    {
      shouldStart = false;
      StartCoroutine(DisableAnimator());
    }

    public void EnableAnim()
    {
      if (!shouldStart)
      {
        GetComponent<Animator>().enabled = true;
        shouldStart = true;
      }
    }
    #endregion

    #region CustomMethods
    IEnumerator DisableAnimator()
    {
      yield return new WaitForSeconds(0.01f);
      GetComponent<Animator>().enabled = false;
    }
    #endregion
  }
}