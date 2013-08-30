using System;
using System.Linq;
using System.Web.Mvc;
using MyMetroApp.MetroUIMvc;

namespace MyMetroApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            // Some temp variables to make life a bit more cleaner
            MetroTile aTile;
            MetroColumn aColumn;
            MetroRow aRow;


            // =============================================================================
            // =============================================================================
            // Everything starts with a screen object
            // =============================================================================
            // =============================================================================
            MetroScreen metroScreen = new MetroScreen(145, 10, 0, 45);


            // =============================================================================
            // =============================================================================
            // Lets create a column (group)
            //      Steps:
            //          1. Add a column to the screen object
            //          2. Add a row to the column
            //          3. Add tiles to your row
            //          4. As necessary, keep adding rows to the column and tiles to rows
            // =============================================================================
            // =============================================================================
            aColumn = metroScreen.AddColumn("Column0", "window.alert('Column 0 title clicked!')");

            // Now a row within this column
            aRow = aColumn.AddRow();

            // How about some tiles to this row, specific to this column
            // Only need to grab the tile if you want to add additional property values
            aTile = aRow.AddTile(TileType.ScrollingText, TileWidth.Wide, TileHeight.Normal, "orange", "Tile0", "window.alert('Tile 0_0_0')");
            aTile.LabelText = "Label";
            aTile.Text.Add("This is a scrolling text tile...");
            aTile.Text.Add("You can add as many lines as needed...");
            aTile.Text.Add("Easy peasy!!");

            // Now another row, within this column
            aRow = aColumn.AddRow();

            // Tiles for this row, specific to this column
            aRow.AddTile(TileType.Simple, TileWidth.Half, TileHeight.Normal, "purple", "Tile1", "window.alert('Tile 0_1_1')");
            aRow.AddTile(TileType.Simple, TileWidth.Half, TileHeight.Normal, "purple", "Tile2", "window.alert('Tile 0_1_2')");

            // Now our final row, within this column
            aRow = aColumn.AddRow();

            // And our final tile in this row, specific to this column
            aTile = aRow.AddTile(TileType.Simple, TileWidth.Wide, TileHeight.Normal, "lightblue", "Tile3", "window.alert('Tile 0_2_3')");
            aTile.Text.Add("This is a simple tile, Text, No Image");


            // =============================================================================
            // =============================================================================
            // Lets create aanother column (group)
            //      Steps:
            //          1. Add a column to the screen object
            //          2. Add a row to the column
            //          3. Add tiles to your row
            //          4. As necessary, keep adding rows to the column and tiles to rows
            //
            // Notice this one has no title and obviously no onClick
            // =============================================================================
            // =============================================================================
            aColumn = metroScreen.AddColumn("Column1");

            // Now a row within this column
            aRow = aColumn.AddRow();

            // How about some tiles to this row, specific to this column
            aRow.AddTile(TileType.Simple, TileWidth.Wide, TileHeight.Normal, "red", "Tile0", "window.alert('Tile 1_0_0')");

            // now another row, within this column
            aRow = aColumn.AddRow();

            // Tiles for this row, specific to this column
            aRow.AddTile(TileType.Simple, TileWidth.Half, TileHeight.Normal, "pink", "Tile1", "window.alert('Tile 1_1_1')");
            aRow.AddTile(TileType.Simple, TileWidth.Half, TileHeight.Normal, "pink", "Tile2", "window.alert('Tile 1_1_2')");

            // now our final row, within this column
            aRow = aColumn.AddRow();

            // and our final tile in this row, specific to this column
            aRow.AddTile(TileType.Simple, TileWidth.Wide, TileHeight.Normal, "lightgreen", "Tile3", "window.alert('Tile 1_2_3')");


            // =============================================================================
            // =============================================================================
            // Lets create another column (group)
            //      Steps:
            //          1. Add a column to the screen object
            //          2. Add a row to the column
            //          3. Add tiles to your row
            //          4. As necessary, keep adding rows to the column and tiles to rows
            //
            // Notice this column has a title, no click event
            // =============================================================================
            // =============================================================================
            aColumn = metroScreen.AddColumn("Column2");

            // Now a row within our column
            aRow = aColumn.AddRow();

            // How about some tiles to this row, specific to this column
            aRow.AddTile(TileType.Simple, TileWidth.Wide, TileHeight.Normal, "red", "Tile0", "window.alert('Tile 2_0_0')");

            // now another row, within this column
            aRow = aColumn.AddRow();

            // Tiles for this row, specific to this column
            aRow.AddTile(TileType.Simple, TileWidth.Half, TileHeight.Normal, "pink", "Tile1", "window.alert('Tile 2_1_1')");
            aRow.AddTile(TileType.Simple, TileWidth.Half, TileHeight.Normal, "pink", "Tile2", "window.alert('Tile 2_1_2')");

            // now our final row, within this column
            aRow = aColumn.AddRow();

            // and our final tile in this row, specific to this column
            aRow.AddTile(TileType.Simple, TileWidth.Wide, TileHeight.Normal, "lightgreen", "Tile3", "window.alert('Tile 2_2_3')");


            // =============================================================================
            // =============================================================================
            // Lets create our final column (group)
            //      Steps:
            //          1. Add a column to the screen object
            //          2. Add a row to the column
            //          3. Add tiles to your row
            //          4. As necessary, keep adding rows to the column and tiles to rows
            //
            // Notice this column has a title, no click event
            // =============================================================================
            // =============================================================================
            aColumn = metroScreen.AddColumn("Column3");

            // Now a row within our column
            aRow = aColumn.AddRow();

            // How about some tiles to this row, specific to this column
            aRow.AddTile(TileType.Simple, TileWidth.Wide, TileHeight.Normal, "red", "Tile0", "window.alert('Tile 3_0_0')");

            // now another row, within this column
            aRow = aColumn.AddRow();

            // Tiles for this row, specific to this column
            aRow.AddTile(TileType.Simple, TileWidth.Half, TileHeight.Normal, "pink", "Tile1", "window.alert('Tile 3_1_1')");
            aRow.AddTile(TileType.Simple, TileWidth.Half, TileHeight.Normal, "pink", "Tile2", "window.alert('Tile 3_1_2')");

            // now our final row, within this column
            aRow = aColumn.AddRow();

            // and our final tile in this row, specific to this column
            aRow.AddTile(TileType.Simple, TileWidth.Wide, TileHeight.Normal, "lightgreen", "Tile3", "window.alert('Tile 3_2_3')");


            // =============================================================================
            // =============================================================================
            // Done with creating our columns and tiles
            //
            // Lets get the html to define our screen
            // =============================================================================
            // =============================================================================
            string colHtml = null;
            string tileHtml = null;
            string configVariables = null;

            // Build our html for the screen
            foreach (MetroColumn column in metroScreen.Columns)
            {
                // first lets get the html for this columns header
                colHtml += column.GetTitleHtml();

                // Lets get the html for the tiles associated with this column
                tileHtml += column.GetTileHtml();

            }

            // create our variables for the javascript side
            configVariables = metroScreen.GetClientConfig();

            // lets put the html and script in the global data space for the view
            ViewData["configVariables"] = configVariables;
            ViewData["metroHtml"] = colHtml + tileHtml;

            return View();
        }

    }
}
