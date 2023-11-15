using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace Phyw
{
    public class BowStringController : MonoBehaviour
    {

        #region Variables

        public UnityEvent OnBowPulled;
        public UnityEvent<float> OnBowReleased;

        [SerializeField] private Transform midPointGrabObject, midPointVisulizer, midPointParent;
        [SerializeField] private BowString bowString;
        [SerializeField][Range(0f, 1f)] private float strecthLimit = 0.3f;
        [SerializeField][Range(1, 10)] private float force = 2f;

        private XRGrabInteractable m_interactable;
        private float strength;
        private Transform m_interactor;

        #endregion

        #region UnityMethods

        private void Awake()
        {
            m_interactable = midPointGrabObject.GetComponent<XRGrabInteractable>();
        }

        void Start()
        {
            m_interactable.selectEntered.AddListener(PrepareBowString);
            m_interactable.selectExited.AddListener(ResetBowString);
        }

        private void Update()
        {
            if (m_interactor == null) return;

            Vector3 midPointLocalSpace = midPointParent.InverseTransformPoint(midPointGrabObject.position);
            float midLocalYAbs = Mathf.Abs(midPointLocalSpace.y);

            HandlePushedBackToStart(midPointLocalSpace);
            HandlePulledBackToLimit(midLocalYAbs, midPointLocalSpace);
            HandlePullingString(midLocalYAbs, midPointLocalSpace);

            bowString.UpdateString(midPointVisulizer.position);
        }



        #endregion

        #region CustomMethods

        private void PrepareBowString(SelectEnterEventArgs arg)
        {
            m_interactor = arg.interactorObject.transform;
            OnBowPulled?.Invoke();
        }

        private void ResetBowString(SelectExitEventArgs arg)
        {

            OnBowReleased?.Invoke(strength * force);
            strength = 0;

            m_interactor = null;
            midPointGrabObject.localPosition = Vector3.zero;
            midPointVisulizer.localPosition = Vector3.zero;
            bowString.UpdateString(null);
        }

        // if in limit
        private void HandlePullingString(float midLocalYAbs, Vector3 midPointLocalSpace)
        {
            if (midPointLocalSpace.y > 0 && midLocalYAbs < strecthLimit)
            {
                strength = Remap(midLocalYAbs, 0, strecthLimit, 0, 1);
                midPointVisulizer.localPosition = new Vector3(0, midPointLocalSpace.y, 0);
            }
        }

        private float Remap(float val, int fromMin, float fromMax, int toMin, int toMax)
        {
            float avg = val - fromMin / fromMax - fromMin;
            return avg * (toMax - toMin) + toMin;
        }

        // if pulled beyond
        private void HandlePulledBackToLimit(float midLocalYAbs, Vector3 midPointLocalSpace)
        {
            if (midPointLocalSpace.y > 0 && midLocalYAbs >= strecthLimit)
            {
                strength = 1;
                midPointVisulizer.localPosition = new Vector3(0, strecthLimit, 0);
            }
        }

        // if pushed 
        private void HandlePushedBackToStart(Vector3 midPointLocalSpace)
        {
            if (midPointLocalSpace.y <= 0)
            {
                strength = 0;
                midPointVisulizer.localPosition = Vector3.zero;
            }
        }

        #endregion
    }
}