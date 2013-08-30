using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMetroApp.MetroUIMvc
{
    public class MetroRow
    {
        public int TopMargin;
        public int LeftMargin;
        public int Width;
        public int Height;

        public List<MetroTile> Tiles;
        
        public MetroColumn Column;
        

        // Initialize our object, the column object this row will belong is required
        public MetroRow(MetroColumn column)
        {
            this.Column = column;

            // Get the last row of our column to calculate the top of this row
            MetroRow lastRowAdded = this.Column.Rows.LastOrDefault();
            this.TopMargin = 0;

            // If there are no rows in this column yet, this is the first
            if (lastRowAdded == null)
            {
                this.TopMargin = column.TilesTopMargin;
            }
            else
            {
                // Calculate based on previous row
                this.TopMargin = lastRowAdded.TopMargin + lastRowAdded.Height + column.SpacingBetweenTiles;
            }

            // All rows need a list to hold their tiles
            this.Tiles = new List<MetroTile>();
        }

        
        // Create a new tile for this row using common base
        public MetroTile AddTile(TileType type, TileWidth width, TileHeight height, string bgColor, string title, string onClick = "", string navUrl = "")
        {
            // Get the last tile added to this row
            MetroTile lastTileAdded = this.Tiles.LastOrDefault();
            int nextLeftMargin = 0;

            // If this is the first tile in the row, margin is column margin
            if (lastTileAdded == null)
            {
                nextLeftMargin = this.Column.LeftMargin;
            }
            else
            {
                // Calculate left margin based on the previous tile in the row
                nextLeftMargin = lastTileAdded.LeftMargin + lastTileAdded.Width + Column.SpacingBetweenTiles;
            }

            // Now create the actual tile based on our calculations
            MetroTile newTile = new MetroTile(this.Column.Position, type, TopMargin, nextLeftMargin, width, height, bgColor, title, onClick, navUrl);

            // Add the new tile to the list of tiles for this row
            this.Tiles.Add(newTile);

            // Recalculate the width and height of this row
            this.Width = this.Width == 0 ? newTile.Width : this.Width + Column.SpacingBetweenTiles + newTile.Width;
            this.Height = this.Height < newTile.Height ? newTile.Height : this.Height;

            // Return the new tile so it can be further worked with
            return newTile;
        }


        // Get the Html for the tiles in this row
        public string GetTileHtml()
        {
            string result = null;

            // Loop over each tile in the row
            foreach (var tile in this.Tiles)
            {
                // Call the lower tile method for its Html
                result += tile.GetHtml();    
            }

            // Return the Html for the tiles in this row
            return result;
        }

    }
}