using UnityEngine;

namespace Phyw
{

    [RequireComponent(typeof(LineRenderer))]

    public class BowString : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform endPoint_1, endPoint_2;
        private LineRenderer m_lineRenderer;

        #endregion

        #region UnityMethods

        private void Awake()
        {
            m_lineRenderer = GetComponent<LineRenderer>();
        }

        void Start()
        {
            UpdateString(null);
        }

        #endregion

        #region CustomMethods

        public void UpdateString(Vector3? midPoint)
        {
            // Check if we have a mid point
            Vector3[] linePoints = new Vector3[midPoint == null ? 2 : 3];
            linePoints[0] = transform.InverseTransformPoint(endPoint_1.position);

            // is so add the value
            if (midPoint != null)
            {
                linePoints[1] = transform.InverseTransformPoint(midPoint.Value);
            }

            // Assign the last value 
            linePoints[^1] = transform.InverseTransformPoint(endPoint_2.position);

            // Pass the obtained values
            m_lineRenderer.positionCount = linePoints.Length;
            m_lineRenderer.SetPositions(linePoints);
        }

        #endregion
    }
}