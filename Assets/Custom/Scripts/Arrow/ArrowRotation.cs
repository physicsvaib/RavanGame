using UnityEngine;


namespace Phyw
{
    public class ArrowRotation : MonoBehaviour
    {

        #region Variables
        [SerializeField] private Rigidbody rb;
        #endregion

        #region UnityMethods

        void Start()
        {

        }

        void FixedUpdate()
        {
            transform.forward = Vector3.Slerp(-transform.forward, rb.velocity.normalized, Time.fixedDeltaTime);
        }
        #endregion

        #region CustomMethods

        #endregion
    }
}