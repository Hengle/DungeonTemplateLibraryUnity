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

using DTL.Random;
using DTL.Util;
using MatrixRange = DTL.Base.Coordinate2DimensionalAndLength2Dimensional;

namespace DTL.Shape {
    public class RandomVoronoi {
        private RandomBase rand = new RandomBase();
        private VoronoiDiagram voronoiDiagram;
        public double probabilityValue { get; set; }
        public int trueColor { get; set; }
        public int falseColor { get; set; }
        
        public bool Draw(int[,] matrix) {
            DTLDelegate.VoronoiDiagramDelegate voronoiDiagramDelegate =
                (ref Pair point, ref int color, uint startX, uint startY, uint w, uint h) => {
                    if (rand.Probability((this.probabilityValue)))
                        color = this.trueColor;
                    else
                        color = this.falseColor;
                };

            voronoiDiagram.Draw(matrix, voronoiDiagramDelegate);
            return true;
        }

        public int[,] Create(int[,] matrix) {
            this.Draw(matrix);
            return matrix;
        }

        /* Clear */

        public RandomVoronoi ClearPointX() {
            this.voronoiDiagram.ClearPointX();
            return this;
        }

        public RandomVoronoi ClearPointY() {
            this.voronoiDiagram.ClearPointY();
            return this;
        }

        public RandomVoronoi ClearWidth() {
            this.voronoiDiagram.ClearWidth();
            return this;
        }

        public RandomVoronoi ClearHeight() {
            this.voronoiDiagram.ClearHeight();
            return this;
        }

        public RandomVoronoi ClearValue() {
            this.voronoiDiagram.ClearValue();
            return this;
        }

        public RandomVoronoi ClearPoint() {
            this.ClearPointX();
            this.ClearPointY();
            return this;
        }

        public RandomVoronoi ClearRange() {
            this.ClearPointX();
            this.ClearPointY();
            this.ClearWidth();
            this.ClearHeight();
            return this;
        }

        public RandomVoronoi Clear() {
            this.ClearRange();
            this.ClearValue();
            return this;
        }

        /* Constructors */

        public RandomVoronoi() {
            voronoiDiagram = new VoronoiDiagram();
        } // default

        public RandomVoronoi(int drawValue) {
            voronoiDiagram = new VoronoiDiagram(drawValue);
        }

        public RandomVoronoi(int drawValue, double probabilityValue) {
            voronoiDiagram = new VoronoiDiagram(drawValue);
            this.probabilityValue = probabilityValue;
        }

        public RandomVoronoi(int drawValue, double probabilityValue, int trueColor) {
            voronoiDiagram = new VoronoiDiagram(drawValue);
            this.probabilityValue = probabilityValue;
            this.trueColor = trueColor;
        }

        public RandomVoronoi(int drawValue, double probabilityValue, int trueColor, int falseColor) {
            voronoiDiagram = new VoronoiDiagram(drawValue);
            this.probabilityValue = probabilityValue;
            this.trueColor = trueColor;
            this.falseColor = falseColor;
        }

        public RandomVoronoi(MatrixRange matrixRange) {
            voronoiDiagram = new VoronoiDiagram(matrixRange);
        }

        public RandomVoronoi(MatrixRange matrixRange, int drawValue) {
            voronoiDiagram = new VoronoiDiagram(matrixRange, drawValue);
        }

        public RandomVoronoi(MatrixRange matrixRange, int drawValue, double probabilityValue) {
            voronoiDiagram = new VoronoiDiagram(matrixRange, drawValue);
            this.probabilityValue = probabilityValue;
        }

        public RandomVoronoi(MatrixRange matrixRange, int drawValue, double probabilityValue, int trueColor) {
            voronoiDiagram = new VoronoiDiagram(matrixRange, drawValue);
            this.probabilityValue = probabilityValue;
            this.trueColor = trueColor;
        }

        public RandomVoronoi(MatrixRange matrixRange, int drawValue, double probabilityValue, int trueColor, int falseColor) {
            voronoiDiagram = new VoronoiDiagram(matrixRange, drawValue);
            this.probabilityValue = probabilityValue;
            this.trueColor = trueColor;
            this.falseColor = falseColor;
        }
    }
}