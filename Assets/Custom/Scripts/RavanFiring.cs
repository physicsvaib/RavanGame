using UnityEngine;


namespace Phyw
{
  public class RavanFiring : MonoBehaviour
  {

    #region Variables

    [SerializeField] GameObject fireBall1, fireBall2, AOE;

    private GameObject player;
    #endregion

    #region UnityMethods

    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

    }
    #endregion

    #region CustomMethods

    public void Fire(string s)
    {
      switch (s)
      {
        case "1H1":
          print("1h1");
          Instantiate(fireBall1, transform.position, transform.rotation);
          break;
        case "2H1":
          Instantiate(fireBall2, transform.position, transform.rotation);
          print("2h1");
          break;
        case "AOE":
          print("AOE");
          Instantiate(AOE, player.transform.position, player.transform.rotation);
          break;
      }
    }

    public void FireOneHand()
    {
      print("One Handed Fire");
    }

    public void FireTwoHanded()
    {
      print("Two Handed Fire");
    }

    public void FireAOE()
    {
      print("AOE");
    }

    public void Fireball(Vector3 start, Vector3 end)
    {

    }

    #endregion
  }
}