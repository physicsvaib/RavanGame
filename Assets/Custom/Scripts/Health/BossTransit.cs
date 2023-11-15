using System.Collections;
using UnityEngine;


namespace Phyw
{
  public class BossTransit : MonoBehaviour
  {

    #region Variables

    [SerializeField] GameObject vfx, text;
    private Animator anim;

    #endregion

    #region UnityMethods

    void Start()
    {
      anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
    #endregion

    #region CustomMethods

    public void ChangeToBoss(float f)
    {

      if (f <= 0)
      {
        //anim.SetTrigger("Death");
        anim.enabled = false;
        Dead();
        //Destroy(gameObject, 4);
      }

    }

    private void Dead()
    {
      //for (int i = 0; i < 10; i++)
      //{
      //  yield return new WaitForSeconds(.01f);
      //  //transform.Rotate(Mathf.Lerp(transform.rotation.x, -30, .2f), 0, 0);
      //  transform.Translate(Vector3.up * -20f);
      //}
      //vfx.transform.position = transform.position;
      text.transform.position = transform.position + new Vector3(0, 60, 0);
      text.transform.LookAt(GameObject.FindWithTag("Player").transform.position);

      vfx.SetActive(true);
      text.SetActive(true);
    }

    IEnumerator DisableAnim()
    {
      yield return new WaitForSeconds(.5f);
    }

    #endregion
  }
}