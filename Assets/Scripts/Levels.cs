using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels
{
    public static Level[] levels = new Level[] {

        new Level(new int[,] { {0,0,0,0},
                               {0,1,1,0},
                               {0,1,1,0},
                               {0,0,0,0},
                               },
                               new Invader(new GridVector(3, 0))),

        new Level(new int[,] { {0,0,0,0,0},
                               {0,1,1,1,0},
                               {0,1,0,1,0},
                               {0,1,0,1,0},
                               {0,1,0,0,0},
                               },
                               new Invader(new GridVector(4, 0))),

            new Level(new int[,] { {0,0,0,1,0},
                                   {0,1,0,1,0},
                                   {0,0,0,0,0},
                                   {1,1,0,1,0},
                                   {0,0,0,1,0},
                                   },
                                       new Invader(new GridVector(4, 0))),


            new Level(new int[,] { {0,0,0,1,0,0,0},
                                   {0,1,0,1,0,1,0},
                                   {0,0,0,0,0,0,0},
                                   {1,1,0,1,0,1,1},
                                   {0,0,0,1,0,0,0},
                                   {0,1,1,1,1,1,0},
                                   {0,0,0,0,0,0,0},
                                   },
                                       new Invader(new GridVector(6, 0))),

             new Level(new int[,] { {0,0,0,0,1,1,0,0},
                                    {1,1,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,1},
                                    {0,0,0,0,0,0,0,0},
                                    {1,1,1,1,1,1,0,0},
                                    {0,0,0,0,0,0,0,0},
                                   },
                                       new Invader(new GridVector(5, 0))),


            new Level(new int[,] {  {0,0,1,1,0,1,1 },
                                    {0,0,0,0,0,1,1 },
                                    {1,0,0,1,0,0,1 },
                                    {0,0,0,1,1,0,1 },
                                    {0,1,0,0,0,0,0 },
                                    {0,0,0,0,0,0,0 },
                                   },
                                       new Invader(new GridVector(5, 0))),

            new Level(new int[,] {  {1,0,0,0,0,0},
                                    {0,0,0,0,0,0},
                                    {0,0,1,1,0,0},
                                    {0,0,1,1,0,0},
                                    {0,0,0,0,0,0},
                                    {0,0,0,0,0,1},
                                   },
                                       new Invader(new GridVector(5, 0))),

             new Level(new int[,] { {1,0,0,0,0,0,0},
                                    {1,0,1,1,1,1,0},
                                    {1,0,1,0,0,0,0},
                                    {1,0,1,0,1,1,0},
                                    {1,0,1,0,1,1,0},
                                    {0,0,1,0,0,0,0},
                                   },
                                       new Invader(new GridVector(5, 0))),

             new Level(new int[,] { {0,0,0,1,0,0,0},
                                    {0,0,0,0,0,0,0},
                                    {0,1,1,1,0,0,0},
                                    {0,0,0,0,0,0,1},
                                    {1,1,1,1,1,0,0},
                                    {0,0,0,1,1,0,0},
                                    {0,1,0,0,0,0,0},
                                   },
                                       new Invader(new GridVector(6, 0))),

             new Level(new int[,] { {0,0,1,0,0,0,0},
                                    {0,0,1,0,1,1,0},
                                    {0,0,1,0,1,1,0},
                                    {1,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,1},
                                    {0,1,1,0,1,1,1},
                                    {0,1,1,0,1,1,1},
                                    {0,0,0,0,1,1,1},
                                   },
                                       new Invader(new GridVector(7, 0))),

    };
}
