using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralRing : MonoBehaviour {

    private const int NUMBER_VERTICES = 64;
    private const float halfWidth = 0.02f;
    private int[] triangleIndices;
    public float centerDistance = 1f;
    public float shrinkingSpeed = 0.1f;
    private MeshFilter mf;
    // Use this for initialization
    void Start () {
        triangleIndices = calculateRingTriangle();
        mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;
        mesh.name = "Procedural Ring";
        mesh.vertices = calculateRingPoints();
        mesh.triangles = triangleIndices;
        mesh.Optimize();
        mesh.RecalculateNormals();
    }
	
	// Update is called once per frame
	void Update () {
        centerDistance -= shrinkingSpeed * Time.deltaTime;
        
        if(centerDistance <= 0.0f)
        {
            Destroy(gameObject);
        } else
        {
            Mesh mesh = mf.mesh;
            mesh.vertices = calculateRingPoints();
            mesh.Optimize();
            mesh.RecalculateNormals();
        }
    }

    Vector3[] calculateRingPoints()
    {
        Vector3[] result = new Vector3[NUMBER_VERTICES * 2];
        for (int i = 0; i < NUMBER_VERTICES; i++)
        {
            float angle = 2 * Mathf.PI / NUMBER_VERTICES * i;
            result[i] = new Vector3(
                    Mathf.Cos(angle) * (centerDistance + halfWidth),
                    Mathf.Sin(angle) * (centerDistance + halfWidth),
                    0
                );
            result[NUMBER_VERTICES + i] = new Vector3(
                    Mathf.Cos(angle) * (centerDistance - halfWidth),
                    Mathf.Sin(angle) * (centerDistance - halfWidth),
                    0
                );
        }
        return result;
    }

    int[] calculateRingTriangle()
    {
        //trust me I've drawn this, much mathematics, very wow
        int[] result = new int[NUMBER_VERTICES * 6];
        for (int i = 0; i < NUMBER_VERTICES - 1; i++)
        {
            result[i * 6] = i;
            result[i * 6 + 1] = (i + NUMBER_VERTICES);
            result[i * 6 + 2] = i + 1;
            result[i * 6 + 3] = i + 1;
            result[i * 6 + 4] = (i + NUMBER_VERTICES);
            result[i * 6 + 5] = (i + NUMBER_VERTICES + 1);
        }
        result[(NUMBER_VERTICES - 1) * 6] = NUMBER_VERTICES - 1;
        result[(NUMBER_VERTICES - 1) * 6 + 1] = 2 * NUMBER_VERTICES - 1;
        result[(NUMBER_VERTICES - 1) * 6 + 2] = 0;
        result[(NUMBER_VERTICES - 1) * 6 + 3] = 0;
        result[(NUMBER_VERTICES - 1) * 6 + 4] = 2 * NUMBER_VERTICES - 1;
        result[(NUMBER_VERTICES - 1) * 6 + 5] = NUMBER_VERTICES;
        return result;
    }
}
