using UnityEngine;

public class RandomGenerateTerrain : MonoBehaviour {
	public int width = 256;
	public int height = 256;
	public int depth = 20;
	public float scale = 20f;
	public float offsetX = 100f;
	public float offsetY = 100f;
	public GameObject[] features;
	void Start () {	
		offsetX = Random.Range( 0f, 9999f);
		offsetY = Random.Range( 0f, 9999f);
		Terrain terrain = GetComponent<Terrain>();
		terrain.terrainData = GenerateTerrain(terrain.terrainData);
		
		// offsetX += Time.deltaTime * 5f;
	}
	TerrainData GenerateTerrain(TerrainData terrainData){
		terrainData.heightmapResolution = width + 1;
		terrainData.size = new Vector3(width, depth, height);
		float[,] heights = GenerateHeights();
		terrainData.SetHeights(0, 0, heights);
		GenerateFeatures(terrainData);
		return terrainData;
	}
	void GenerateFeatures(TerrainData terrainData){
		for(int x = 0; x < width; x++){
			if(Random.Range(0f,100f) < 90 && x > 450 && x < 550){
				continue;
			}
			for(int y = 0; y < height; y++){
				if(y > 450 && y < 550){
					if( (x > 450 && x < 550) || (Random.Range(0f,100f) < 90)){
						continue;
					}
				}
				if (Random.Range(0f,100f) < 0.5f){
					int featureType = (int)Random.Range(0f, features.Length);
					float height = terrainData.GetHeight(x,y);
					GameObject feature = (GameObject) Instantiate(features[featureType], transform.position + new Vector3(x, height, y), Quaternion.identity);
				}
			}
		}
	}
	float[,] GenerateHeights(){
		float[,] heights = new float[width, height];
		for(int x = 0; x < width; x++){
			for(int y = 0; y < height; y++){
				if( (x > 450 && x < 550) && (y > 450 && y < 550)){
					heights[x,y] = 1f;
					continue;
				}
				heights[x,y] = CalculateHeight(x,y);
			}
		}
		return heights;
	}
	float CalculateHeight ( int x, int y){
		float xCoord = (float) x / width * scale + offsetX;
		float yCoord = (float) y / height * scale + offsetY;
		return Mathf.PerlinNoise(xCoord, yCoord);
	}

}
