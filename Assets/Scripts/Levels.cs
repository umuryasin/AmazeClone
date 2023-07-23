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
                               new Invader(new GridVector(3, 0)),
                               Color.red),

        new Level(new int[,] { {0,0,0,0,0},
                               {0,1,1,1,0},
                               {0,1,0,1,0},
                               {0,1,0,1,0},
                               {0,1,0,0,0},
                               },
                               new Invader(new GridVector(4, 0)),
                               Color.green),

            new Level(new int[,] { {0,0,0,1,0},
                                   {0,1,0,1,0},
                                   {0,0,0,0,0},
                                   {1,1,0,1,0},
                                   {0,0,0,1,0},
                                   },
                                       new Invader(new GridVector(4, 0)),
                                       Color.yellow),


            new Level(new int[,] { {0,0,0,1,0,0,0},
                                   {0,1,0,1,0,1,0},
                                   {0,0,0,0,0,0,0},
                                   {1,1,0,1,0,1,1},
                                   {0,0,0,1,0,0,0},
                                   {0,1,1,1,1,1,0},
                                   {0,0,0,0,0,0,0},
                                   },
                                       new Invader(new GridVector(6, 0)),
                                       Color.magenta),

             new Level(new int[,] { {0,0,0,0,1,1,0,0},
                                    {1,1,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,1},
                                    {0,0,0,0,0,0,0,0},
                                    {1,1,1,1,1,1,0,0},
                                    {0,0,0,0,0,0,0,0},
                                   },
                                       new Invader(new GridVector(5, 0)),
                                       Color.blue),


            new Level(new int[,] {  {0,0,1,1,0,1,1 },
                                    {0,0,0,0,0,1,1 },
                                    {1,0,0,1,0,0,1 },
                                    {0,0,0,1,1,0,1 },
                                    {0,1,0,0,0,0,0 },
                                    {0,0,0,0,0,0,0 },
                                   },
                                       new Invader(new GridVector(5, 0)),
                                       Color.red),

            new Level(new int[,] {  {1,0,0,0,0,0},
                                    {0,0,0,0,0,0},
                                    {0,0,1,1,0,0},
                                    {0,0,1,1,0,0},
                                    {0,0,0,0,0,0},
                                    {0,0,0,0,0,1},
                                   },
                                       new Invader(new GridVector(5, 0)),
                                       Color.green),

             new Level(new int[,] { {1,0,0,0,0,0,0},
                                    {1,0,1,1,1,1,0},
                                    {1,0,1,0,0,0,0},
                                    {1,0,1,0,1,1,0},
                                    {1,0,1,0,1,1,0},
                                    {0,0,1,0,0,0,0},
                                   },
                                       new Invader(new GridVector(5, 0)),
                                       Color.yellow),

             new Level(new int[,] { {0,0,0,1,0,0,0},
                                    {0,0,0,0,0,0,0},
                                    {0,1,1,1,0,0,0},
                                    {0,0,0,0,0,0,1},
                                    {1,1,1,1,1,0,0},
                                    {0,0,0,1,1,0,0},
                                    {0,1,0,0,0,0,0},
                                   },
                                       new Invader(new GridVector(6, 0)),
                                       Color.magenta),

             new Level(new int[,] { {0,0,1,0,0,0,0},
                                    {0,0,1,0,1,1,0},
                                    {0,0,1,0,1,1,0},
                                    {1,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,1},
                                    {0,1,1,0,1,1,1},
                                    {0,1,1,0,1,1,1},
                                    {0,0,0,0,1,1,1},
                                   },
                                       new Invader(new GridVector(7, 0)),
                                       Color.blue),

    };
}
