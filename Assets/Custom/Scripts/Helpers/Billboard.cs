using UnityEngine;


namespace Phyw
{
  public class Billboard : MonoBehaviour
  {

    #region Variables
    [SerializeField] Transform toFollow;
    [SerializeField] bool shouldYRotate = true;
    #endregion

    #region UnityMethods

    private void Start()
    {
      if (toFollow == null)
      {
        toFollow = Camera.main.transform;
      }
    }

    void Update()
    {
      if (shouldYRotate)
      {
        Vector3 to = transform.position - toFollow.position;
        to.y = transform.position.y;
        transform.LookAt(to);
      }
      else
      {
        transform.LookAt(toFollow.position);
      }
    }
    #endregion

    #region CustomMethods

    #endregion
  }
}