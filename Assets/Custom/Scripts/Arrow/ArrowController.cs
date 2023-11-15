using System.Collections;
using UnityEngine;

namespace Phyw
{
  public class ArrowController : MonoBehaviour
  {

    #region Variables

    [SerializeField] private GameObject midPointVisual, arrowPrefab, arrow;
    [SerializeField] private Transform arrowSpawn;
    [SerializeField] private float speed = 10;

    private Material mat;

    #endregion

    #region UnityMethods
    private void Start()
    {
      mat = arrow.GetComponent<MeshRenderer>().sharedMaterial;
    }
    #endregion

    #region CustomMethods

    [ContextMenu("Arow")]
    public void PrepareArrow()
    {
      midPointVisual.SetActive(true);
      StartCoroutine(ArrowDissolve());
    }

    private IEnumerator ArrowDissolve()
    {
      for (int i = -6; i < 11; i++)
      {
        yield return new WaitForSeconds(.1f);
        print(mat.HasFloat("_Cutoff_Height"));
        mat.SetFloat("_Cutoff_Height", i * 2);
      }
    }

    [ContextMenu("Arrow")]
    public void ShootArrow()
    {
      ReleaseArrow(.1f);
    }

    public void ReleaseArrow(float forceAmount)
    {
      midPointVisual.SetActive(false);

      GameObject arr = Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation);
      arr.transform.localScale = Vector3.one * .05f;
      Vector3 force = -midPointVisual.transform.up * (forceAmount + 1) * speed;
      arr.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

    }

    #endregion
  }
}