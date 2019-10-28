using Vaser;
using UnityEngine;
using System.Collections.Generic;

public class Demo : MonoBehaviour {

    private void Start() {
        Mesh mesh = new Mesh();

        VertexArrayHolder vah = new VertexArrayHolder();

        Point A = new Point(-1.5f, 0.75f);
        Point B = new Point(1f, 1f);
        Point C = new Point(-1f, -1.25f);
        Point D = new Point(0.5f, -1f);
        vah.Push3(A, B, C, Color.red, Color.red, Color.red, true, false, true);
        vah.Push3(C, B, D, Color.red, Color.red, Color.red, false, true, true);

        mesh.SetVertices(vah.GetVertices());
        mesh.SetUVs(0, vah.GetUVs());
        mesh.SetColors(vah.GetColors());
        mesh.SetTriangles(vah.GetTriangles(), 0);

        /*List<Vector3> positions = new List<Vector3>();
        List<Vector4> texCoord0 = new List<Vector4>();
        List<Color> colors = new List<Color>();
        List<int> indices = new List<int>();

        positions.Add(new Vector3(-1.5f, 0.75f, 0));
        positions.Add(new Vector3(1, 1, 0));
        positions.Add(new Vector3(-1, -1.25f, 0));
        positions.Add(new Vector3(0.5f, -1, 0));

        colors.Add(Color.red);
        colors.Add(Color.green);
        colors.Add(Color.blue);
        colors.Add(Color.yellow);

        texCoord0.Add(new Vector4(1, -1, 0, 0));
        texCoord0.Add(new Vector4(-1, -1, 0, 0));
        texCoord0.Add(new Vector4(1, 1, 0, 0));
        texCoord0.Add(new Vector4(-1, 1, 0, 0));

        indices.Add(0);
        indices.Add(1);
        indices.Add(2);
        indices.Add(2);
        indices.Add(1);
        indices.Add(3);

        mesh.SetVertices(positions);                      // set our position buffer
        mesh.SetUVs(0, texCoord0);                        // set a tex coord buffer (not sure if you'll need this or not)
        mesh.SetColors(colors);                           // set our color buffer
        mesh.SetTriangles(indices, 0);                    // set our index buffer
        */
        GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.transform.localScale = new Vector3(1,1,1);
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Vaser/Rectangle");
    }
}