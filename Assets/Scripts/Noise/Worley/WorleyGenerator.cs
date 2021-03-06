﻿using UnityEngine;
using System.Collections;

public class WorleyGenerator : MonoBehaviour {

    public int seed;
    [Range(128, 512)] public int dimension;
    [Range(1, 1)] public int n;
    [Range(5, 20)] public int nFeatures;
    public bool autoUpdate;
    Terrain terrainMesh;

    public void GenerateMap() {
        terrainMesh = GetComponent<Terrain>();
        float[,] noiseMap = Worley.GenerateNoiseMap(seed, dimension, n, nFeatures);
        TerrainGenerator.GenerateTerrainMesh(terrainMesh, noiseMap, true);
    }

    public void flattenMap() {
        terrainMesh = GetComponent<Terrain>();
        float[,] map = new float[dimension, dimension];

        // Flatten the map - set all height values to 0
        for (int x = 0; x < dimension; x++)
            for (int y = 0; y < dimension; y++)
                map[x, y] = 0;

        TerrainGenerator.GenerateTerrainMesh(terrainMesh, map, false);
    }
}
