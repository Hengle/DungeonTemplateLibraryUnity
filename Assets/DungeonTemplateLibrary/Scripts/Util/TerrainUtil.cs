﻿/*#######################################################################################
    Copyright (c) 2017-2019 Kasugaccho
    Copyright (c) 2018-2019 As Project
    https://github.com/Kasugaccho/DungeonTemplateLibrary
    wanotaitei@gmail.com

    DungeonTemplateLibraryUnity
    https://github.com/sitRyo/DungeonTemplateLibraryUnity
    seriru.rcvmailer@gmail.com

    Distributed under the Boost Software License, Version 1.0. (See accompanying
    file LICENSE_1_0.txt or copy at http://www.boost.org/LICENSE_1_0.txt)
#######################################################################################*/

// Terrainの生成, heightMapの生成など

using System.Collections.Generic;
using UnityEngine;
using DTL.Shape;

namespace DTL.Util {
    public class TerrainUtil {
        public Terrain terrain { get; private set; }
        public TerrainData terrainData { get; private set; }
        public List<float> textureToHeight;
        public int depth { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public float[,] matrix { get; private set; }

        private List<Texture2D> texture2D;
        private ITerrainDrawer terrainGenerator;


        public void Draw() {
            Generate();
            SetTerrainData();
            var textureMap = GetTexture(matrix, terrainData.alphamapWidth, terrainData.alphamapHeight);
            terrainData.SetHeights(0, 0, matrix);
            terrainData.SetAlphamaps(0, 0, textureMap);
        }


        // Smoothどうするか？
        // 19/11/17 とりあえずいいかな...
        // Todo smooth関数をDTL側で提供するか？
        private void Generate() {
            matrix = new float[height, width];
            terrainGenerator.DrawNormalize(matrix);
        }

        // 各種情報の設定
        private void SetTerrainData() {
            terrainData.size = new Vector3(width, depth, height);
            var alphaMapResolution = Mathf.Max(height, width);
            var heightMapResolution = Mathf.Max(height, width);
            var splatPrototypeArray = this.SetSplatPrototypes();
            SetResolutions(alphaMapResolution, heightMapResolution);
            terrainData.splatPrototypes = splatPrototypeArray;
        }

        // heightMapの解像度設定
        private void SetResolutions(int alphaR, int heightR) {
            this.terrainData.alphamapResolution = alphaR;
            this.terrainData.heightmapResolution = heightR;
        }

        // Textureの設定
        private SplatPrototype[] SetSplatPrototypes() {
            var len = this.texture2D.Count;
            var splatPrototype = new SplatPrototype[len];
            for (int i = 0; i < len; ++i) {
                splatPrototype[i] = new SplatPrototype();
                splatPrototype[i].tileSize = Vector2.one;
                splatPrototype[i].texture = texture2D[i];
            }

            return splatPrototype;
        }

        // HeightMapとテクスチャを対応させる
        private float[,,] GetTexture(float[,] matrix, int w, int h) {
            var map = new float[w, h, texture2D.Count];
            for (var y = 0; y < h; ++y) {
                for (var x = 0; x < h; ++x) {
                    var idx = LowerBound(this.textureToHeight, matrix[y, x]);
                    map[y, x, idx] = 1f;
                }
            }

            return map;
        }

        // binary search
        // list<T>.BinarySearchはstd::lower_boundのように動かないために自作
        // indexを返す
        private int LowerBound(List<float> list, float value) {
            var left = 0;
            var right = list.Count;
            while (left + 1 < right) {
                int mid = (left + right) / 2;
                if (value > list[mid]) {
                    left = mid;
                }
                else {
                    right = mid;
                }
            }

            return left;
        }

        // 最初にheightMapとテクスチャの関係が指定されなかったときに呼ばれる関数
        private void SetTextureToHeight() {
            var len = this.texture2D.Count;
            this.textureToHeight = new List<float>();
            var hValue = 0.0f;
            var dh = (float) 1.0f / len;

            this.textureToHeight.Add(hValue);
            for (int i = 1; i < len; ++i)
                textureToHeight.Add(hValue + dh);
        }

        public TerrainUtil(Terrain terrain, List<Texture2D> texture2D, ITerrainDrawer terrainGenerator,
            int height, int width, int depth) {
            this.terrain = terrain;
            this.texture2D = texture2D;
            this.terrainGenerator = terrainGenerator;
            this.terrainData = terrain.terrainData;
            this.height = height;
            this.width = width;
            this.depth = depth;
            SetTextureToHeight();
        }

        public TerrainUtil(Terrain terrain, List<Texture2D> texture2D, ITerrainDrawer terrainGenerator,
            int height, int width, int depth, List<float> textureToHeight) {
            this.terrain = terrain;
            this.texture2D = texture2D;
            this.terrainGenerator = terrainGenerator;
            this.terrainData = terrain.terrainData;
            this.textureToHeight = textureToHeight;
            this.height = height;
            this.width = width;
            this.depth = depth;
        }
    }
}