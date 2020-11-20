﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWR_Tracker.Classes.Maps
{
    public struct GridTile
    {
        public GridTile(int tileIndex, bool isKnown)
        {
            TileIndex = tileIndex;
            IsKnown = isKnown;
        }

        public int TileIndex;
        public bool IsKnown;
    }

    public class DWOverworldMap
    {
        private const int baseOffset = 0x1D5D;
        private const int gridSize = 120;
        private GridTile[,] grid = new GridTile[gridSize, gridSize];
        private int tileSize = 16;

        public DWOverworldMap()
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    grid[x, y] = new GridTile((int)TileName.Water, false); // (int)TileName.Water;
                }
            }
        }

        public void DecodeMap()
        {
            DWProcessReader reader = DWGlobals.ProcessReader;
            Func<int, int> read = offset => reader.Read(baseOffset + offset, 1, 3)[0];
            int count, tileIndex;

            for (int y = 0, byteCtr = 0; y < gridSize; y++)
            {
                int mapByte = read(byteCtr);
                if (mapByte == 0xFF) { break; }
                tileIndex = mapByte >> 4;
                count = mapByte & 0xF;

                for (int x = 0; x < gridSize; x++)
                {
                    grid[x, y] = new GridTile(tileIndex, false);
                    if (count == 0)
                    {
                        mapByte = read(++byteCtr);
                        if (mapByte == 0xFF) { break; }
                        tileIndex = mapByte >> 4;
                        count = mapByte & 0xF;
                    }
                    else
                    {
                        count--;
                    }
                }
            }
        }

        public Image GetImage()
        {
            Bitmap image = new Bitmap(gridSize * tileSize, gridSize * tileSize);
            Graphics g = Graphics.FromImage(image);

            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    GridTile tile = grid[x, y];
                    int tileIndex = tile.IsKnown ? tile.TileIndex : (int)TileName.Unknown;
                    Image tileImage = DWRTiles[tileIndex].Image;
                    g.DrawImage(tileImage, new Point(x * tileSize, y * tileSize));
                }
            }
            return image;
        }

        public void Discover(int x, int y)
        {
            for (int iy = -7; iy < 7; iy++)
            {
                for (int ix = -8; ix < 8; ix++)
                {
                    if (x < 0 || x > 119 || y < 0 || y > 119) { continue; }
                    grid[x + ix, y + iy].IsKnown = true;
                }
            }
        }

        public static DWTile[] DWRTiles = new DWTile[14]
        {
            new DWTile("Grass", "grass.png"),
            new DWTile("Desert", "desert.png"),
            new DWTile("Hill", "hill.png"),
            new DWTile("Mountain", "mountain.png"),
            new DWTile("Water", "water.png"),
            new DWTile("Block", "block.png"),
            new DWTile("Forest", "forest.png"),
            new DWTile("Swamp", "swamp.png"),
            new DWTile("Town", "town.png"),
            new DWTile("Cave", "cave.png"),
            new DWTile("Castle", "castle.png"),
            new DWTile("Bridge", "bridge.png"),
            new DWTile("Stairs Down", "empty.png"),
            new DWTile("Unknown", "unknown.png")
        };
    }

    public enum TileName
    {
        Grass,
        Desert,
        Hill,
        Mountain,
        Water,
        Block,
        Forest,
        Swamp,
        Town,
        Cave,
        Castle,
        Bridge,
        StairsDown,
        Unknown
    }

    
}