using UnityEngine;


namespace Phyw
{
  public class MeshGenerator : MonoBehaviour
  {

    #region Variables

    [SerializeField] Transform pivot;

    private Mesh mesh;
    private int index;
    private Vector3[] verts;
    private int[] triangles;

    #endregion

    #region UnityMethods

    void Start()
    {
      mesh = new Mesh();
      GetComponent<MeshFilter>().mesh = mesh;
      print("Yo ");

      CreateShape();
      UpdateMesh();
    }

    private void UpdateMesh()
    {
      mesh.Clear();
      mesh.vertices = verts;
      mesh.triangles = triangles;
    }

    private void CreateShape()
    {
      verts = new Vector3[]{
        new Vector3(0,0,0),
        new Vector3(1,0,0),
        new Vector3(0,1,0),
        new Vector3(1,1,0),
      };

      triangles = new int[] { 0, 1, 2, 1, 3, 2 };
    }

    private void UpdateVert()
    {

      int currentIndex = index % verts.Length;
      verts[currentIndex] = new Vector3(-pivot.position.x, pivot.position.y, 0);
      print(verts[currentIndex]);
      UpdateMesh();
    }

    void Update()
    {
      UpdateIndex();
    }

    private void UpdateIndex()
    {
      if (Input.GetKeyDown(KeyCode.Z))
      {
        index++;
        int currentIndex = index % verts.Length;
        Vector3 vec = verts[currentIndex];
        vec.x = -vec.x;
        pivot.position = vec;
      }
    }
    #endregion

    #region CustomMethods

    public void UpdateWholeMesh()
    {
      UpdateVert();
    }

    #endregion
  }
}