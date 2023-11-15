using UnityEngine;

public class B_WalkingRage : StateMachineBehaviour
{

  [SerializeField] private float speed = .1f;
  [SerializeField] private int Counter = 1500;
  private Transform playerTrans;
  private Vector3 randLoc;
  private Transform trans;
  int numCounter = 0;

  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    if (playerTrans == null)
    {
      playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }
    if (trans == null)
    {
      trans = animator.GetComponent<Transform>();
    }
    numCounter = 0;

    //CorrectedLookAt();
    FindNewLocation();
    Debug.Log(randLoc);
  }

  private void FindNewLocation()
  {
    randLoc = new Vector3(Random.Range(-35.0f, 35.0f), 0, Random.Range(-35, 35.0f));
    Debug.Log(randLoc);
    numCounter = 0;
  }

  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    numCounter++;

    if (numCounter < Counter)
    {

      Vector3 cachedVal = (randLoc - playerTrans.position).normalized;
      trans.LookAt(playerTrans);

      trans.position += (cachedVal * speed * Time.deltaTime);
    }
    else
    {
      FindNewLocation();
      //hasCalledOnce = true;
    }
  }

  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    CorrectedLookAt();
    animator.ResetTrigger("AOE");
    animator.ResetTrigger("Fire");
  }

  private void CorrectedLookAt()
  {
    Vector3 playerLoc = playerTrans.position;
    playerLoc.y = trans.position.y;
    trans.LookAt(playerLoc);
  }

  void OnChange(Animator anim)
  {
    FindNewLocation();
    // Change this to any state

    //int random = Random.Range(0, 5);
    //Debug.Log(random);
    //switch (random % 2)
    //{
    //  case 0:
    //    {
    //      anim.SetTrigger("AOE");
    //      break;
    //    }
    //  case 1:
    //    {
    //      anim.SetTrigger("Fire");
    //      break;
    //    }
    //}

  }

}
