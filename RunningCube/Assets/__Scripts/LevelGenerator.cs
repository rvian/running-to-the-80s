using UnityEngine;

// Ferramenta para gerar nivel conforme as cores de pixel de uma imagem.
// A imagem deve ter as seguitnes dimensões para ser usada numa pista de 
// 500 unidades. 100x5 (width x height)

public class LevelGenerator : MonoBehaviour{

    public Texture2D map;
    public Transform obstacleContainer;
    public ColorToPrefab[] colorMappings;
    public float xDistance = 10;

    // Le os pixeis da imagem.
    public void GenerateMap()
    {
        // Escaneia os pixeis X (height).
        for (int x = 0; x < map.width; x++)
        {
            // Então escaneia os pixels Y (width).
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);
        // Se o pixel for transparente, ignorar.
        if (pixelColor.a == 0)
        {
            return;
        }
  
        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                // Posição instanciado. X sendo a distância entre os objetos na pista
                // e Z sendo a distância entre os objetos na mesma linha.
                
                Vector3 position = new Vector3(x * xDistance,
                                                0f,
                                                z * colorMapping.prefab.transform.localScale.z);

                Instantiate(colorMapping.prefab,
                            position,
                            Quaternion.identity,
                            obstacleContainer);
            }
        }
    }

    // Limpa os objetos instanciados pelo levelGenerator. Desde que sejam
    // childs do obstacleContainer.
    public void LevelCleaner()
    {
        int childCount = obstacleContainer.transform.childCount;

        if (childCount != 0)
        {
            for (int i = childCount - 1; i >= 0; i--)
            {
                GameObject.DestroyImmediate(obstacleContainer.transform.GetChild(i).gameObject);
            }
        }
        else Debug.Log("Level já limpo!");
    }
}
