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

using DTL.Console;
using UnityEngine;
using DTL.Shape;

public class GeneratePerlinSolitaryIsland : MonoBehaviour {
    public int height = 48;
    public int width = 32;

    private PerlinSolitaryIsland perlinSolitaryIsland;

    private void Start () {
        var matrix = new int[height, width];
        perlinSolitaryIsland = new PerlinSolitaryIsland(0.8, 0.4, 6.0, 8, 60);
        perlinSolitaryIsland.Draw(matrix);

        new OutputConsole().Draw(matrix);
    }


}

