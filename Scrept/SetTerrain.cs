using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SetTerrain : MonoBehaviour
{
    public int w = 100;
    public int h = 100;
 
    public Texture2D texture;
 
    
 
    public Color tu = Color.yellow;
    public Color cao = Color.green;

    // Start is called before the first frame update
    private NavMeshSurface sufe;
    
    
    void Start()
    {
        

        // image.material = material;
        BuildMap();
        sufe=gameObject.AddComponent<NavMeshSurface>();
        sufe.BuildNavMesh();

    }

    void BuildMap()
    {
        texture = new Texture2D(w, h);
                VertexHelper vh = new VertexHelper();
                for (int x = 0; x < w; x++)
                {
                    for (int z = 0; z < h; z++)
                    {
                        float y = Mathf.PerlinNoise(x * 0.1f, z * 0.1f);
                        
                        float uvx=(float)x/(float)(w-1);
                        float uvy=(float)z/(float)(h-1);
         
                        Color color = Color.Lerp(tu,cao,y);
                        texture.SetPixel(x,z,color);
                        vh.AddVert(new Vector3(x,y*10,z),Color.white,new Vector2(uvx,uvy));
                        if (x!=w-1&&z!=h-1)
                        {
                            vh.AddTriangle(x*h+z,x*h+z+1,(x+1)*h+z+1);
                            vh.AddTriangle(x*h+z,(x+1)*h+z+1,(x+1)*h+z);
                        }
                    }
                }
                
                texture.Apply();
                Mesh mesh = new Mesh();
                vh.FillMesh(mesh);
                GetComponent<MeshFilter>().mesh = mesh;
                GetComponent<MeshCollider>().sharedMesh = mesh;
         
                Material material = new Material(Shader.Find("Unlit/Transparent"));
                material.mainTexture = texture;
                GetComponent<MeshRenderer>().material = material;
        
                
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
