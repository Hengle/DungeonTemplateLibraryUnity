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

namespace DTL.Util {

    public static class MatrixUtil {

        public static uint GetX<T>(T[,] matrix) {
            return (uint) matrix.GetLength(1);
        }

        public static uint GetY<T>(T[,] matrix) {
            return (uint) matrix.GetLength(0);
        }

    }
}

