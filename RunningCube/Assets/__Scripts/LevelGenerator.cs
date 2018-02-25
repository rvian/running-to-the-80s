using UnityEngine;

// Ferramenta para gerar nivel conforme as cores de pixel de uma imagem.
// A imagem deve ter as seguitnes dimensões para ser usada numa pista de 
// 500 unidades. 100x5 (width x height)

public class LevelGenerator : MonoBehaviour{

    public Texture2D map;
    public Transform obstacleContainer;
    public ColorToPrefab[] colorMappings;

    public void GenerateMap()
    {
        // Escaneia os pixeis X (height)
        for (int x = 0; x < map.width; x++)
            // Então escaneia os pixels Y (width)
            for (int y = 0; y < map.height; y++)
                GenerateTile(x, y);
    }

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);
        //se o pixel for transparent, ignorar
        if (pixelColor.a == 0)
            return; 
  
        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x*10,0f,z*3);
                Instantiate(colorMapping.prefab,
                            position,
                            Quaternion.identity,
                            obstacleContainer.parent);
            }
        }
    }
}
