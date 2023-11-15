using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(LineRenderer))]

public class PullInteraction : XRBaseInteractable
{

    public static event Action<float> pullActionRelease;
    [SerializeField] GameObject notch;
    [SerializeField] Transform start;
    [SerializeField] Transform end;

    public float pullAmountPossible { get; private set; } = 0;

    private LineRenderer _lineRenderer;
    private IXRSelectInteractable _interactor = null;

    protected override void Awake()
    {
        base.Awake();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetPullInteractor(SelectEnterEventArgs args)
    {
        _interactor = args.interactableObject;
    }

    public void Release()
    {
        pullActionRelease?.Invoke(pullAmountPossible);
        _interactor = null;
        pullAmountPossible = 0;
        notch.transform.localPosition = new Vector3(notch.transform.localPosition.x,
            notch.transform.localPosition.y, 0);
        UpdateString();
    }

    private void UpdateString()
    {
        Vector3 linePos = Vector3.up * (Mathf.Lerp(start.transform.position.y, end.transform.position.y, pullAmountPossible) - 14.8f);

        notch.transform.localPosition = new Vector3(notch.transform.localPosition.x, linePos.y, notch.transform.localPosition.y);
        _lineRenderer.SetPosition(1, linePos);
        print(linePos);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if (isSelected)
            {
                Vector3 pullPos = _interactor.transform.position;
                pullAmountPossible = CalculatePull(pullPos);
                UpdateString();
            }
        }
    }

    private float CalculatePull(Vector3 pullPos)
    {
        Vector3 pullDir = pullPos - start.position;
        Vector3 targetDirection = end.position - start.position;
        float maxLength = targetDirection.magnitude;

        targetDirection.Normalize();
        float pullValue = Vector3.Dot(pullDir, targetDirection) / maxLength;
        return Mathf.Clamp(pullValue, 0.0f, 1.0f);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
