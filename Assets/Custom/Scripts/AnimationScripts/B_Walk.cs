using UnityEngine;

public class B_Walk : StateMachineBehaviour
{

  [SerializeField] float speed = 1;
  [SerializeField] float range = 4;
  bool shouldMove;
  private Transform playerTrans;
  private Transform trans;

  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    shouldMove = true;
    if (playerTrans == null)
    {
      playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }
    if (trans == null)
    {
      trans = animator.GetComponent<Transform>();
    }
  }

  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    if (shouldMove)
    {
      if (Vector3.Distance(trans.position, playerTrans.position) > range)
      {
        trans.Translate(Vector3.MoveTowards(trans.position, playerTrans.position, Time.deltaTime).normalized * speed);
        CorrectedLookAt();
      }
      else
      {
        animator.SetBool("Walking", false);
      }
    }
  }

  private void CorrectedLookAt()
  {
    Vector3 playerLoc = playerTrans.position;
    playerLoc.y = trans.position.y;
    trans.LookAt(playerLoc);
  }

  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {

  }

}
