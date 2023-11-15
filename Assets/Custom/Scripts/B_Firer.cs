using Phyw;
using UnityEngine;

public class B_Firer : StateMachineBehaviour
{

  [SerializeField] private string fireName;
  [SerializeField] private float delay = .5f;
  float delayTime = 0;
  private RavanFiring firer;
  bool doneOnce;

  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    delayTime = 0;
    doneOnce = false;
    if (firer == null)
      firer = animator.GetComponent<RavanFiring>();
  }

  public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    if (delayTime <= delay)
    {
      delayTime += Time.deltaTime;
    }
    else
    {
      if (!doneOnce)
      {
        doneOnce = true;
        firer.Fire(fireName);
      }

    }
  }


  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {

  }


}
