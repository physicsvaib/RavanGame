using UnityEngine;

public class B_Idle : StateMachineBehaviour
{

  private Transform playerTrans;
  [SerializeField] private int timerCount = 500;
  int timer;

  // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    if (playerTrans == null)
    {
      playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }
    timer = 0;
  }

  // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    // loop this state for like 3 secs
    // after that choose a state to transit to 
    timer++;
    if (timer > timerCount)
    {
      OnChange(animator);
    }
  }

  // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    animator.ResetTrigger("Fire");
  }

  void OnChange(Animator anim)
  {
    // Change this to any state

    int random = Random.Range(0, 5);

    switch (random % 2)
    {
      case 0:
        {
          anim.SetBool("Walking", true);
          break;
        }
      case 1:
        {
          anim.SetTrigger("Fire");
          break;
        }
    }

  }

}
