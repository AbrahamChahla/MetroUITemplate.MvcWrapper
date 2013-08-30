using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Ajax.Utilities;

namespace MyMetroApp.MetroUIMvc
{
    public class MetroColumn
    {
        public int Position;
        public int LeftMargin;
        public int TilesTopMargin;
        public string TitleText;
        public string OnClick;
        public int Width;
        public string NavUrl;

        public int SpacingBetweenTiles;

        public List<MetroRow> Rows;


        // Initialize our column object, passing the screen required, all others optional
        public MetroColumn(MetroScreen metroScreen, string titleText = "", string onClick = "", string navUrl = "")
        {
            // Look to see if there is a "last" column in the list, if not returns null
            MetroColumn lastColumnAdded = metroScreen.Columns.LastOrDefault();

            // Set the defaults for columns
            this.LeftMargin = metroScreen.TilesStartLeftMargin;
            this.TilesTopMargin = metroScreen.TilesStartTopMargin;
            this.SpacingBetweenTiles = metroScreen.SpacingBetweenTiles;
            this.NavUrl = navUrl;
            this.Position = 0;

            // If this is not the first column, calculate the left margins based on the previous column
            if (lastColumnAdded != null)
            {
                lastColumnAdded.Width = lastColumnAdded.Rows.OrderBy(e => e.Width).LastOrDefault().Width;
                this.LeftMargin = lastColumnAdded.LeftMargin + lastColumnAdded.Width + metroScreen.SpacingBetweenColumns;
                this.Position = lastColumnAdded.Position+1;
            }

            // Set the column title and click event
            this.TitleText = titleText;
            this.OnClick = onClick;

            // Create our default list of rows for this column
            this.Rows = new List<MetroRow>();
        }



        // Add a new row to the column
        public MetroRow AddRow()
        {
            var newRow = new MetroRow(this);
            Rows.Add(newRow);

            // Return the row object so it can be worked with
            return newRow;
        }


        // Create the html for a column title
        public string GetTitleHtml()
        {
            string result = "";
            string onClickValue = "";
            string titleValue = "&nbsp;";
            string navUrlValue = "";

            // Html template, placeholders for our variables
            string titleHtml = "<a {0} id=\"groupTitle{1}\" class=\"groupTitle\" " +
                                "style=\"margin-left: {2}px; margin-top: {3}px; cursor: pointer;\" " +
                                "{4}> " +
                                "<h3>{5}</h3>" +
                                "</a>";

            // If there is a title... great... create the values
            if (!this.TitleText.IsNullOrWhiteSpace())
            {
                titleValue = this.TitleText;

                // Is there a nav url
                if (!this.NavUrl.IsNullOrWhiteSpace())
                    navUrlValue = string.Format("href=\"{0}\"", this.NavUrl);

                // Is there an onclick
                if (!this.OnClick.IsNullOrWhiteSpace())
                    onClickValue = string.Format("onclick=\"{0}\"", this.OnClick);
            }

            // Merge the values with the template
            result = string.Format(titleHtml, navUrlValue, this.Position, this.LeftMargin, 0, onClickValue, titleValue);

            // Return the Html for this title
            return result;

        }

        // In this column object, function to get html
        // Actually calls the GetTileHtml from each row
        public string GetTileHtml()
        {
            string result = null;

            // Loop over each row in our column
            foreach (var row in this.Rows)
            {
                // Get the html for each row of tiles
                result += row.GetTileHtml();                    
            }

            // Return the Html for this columns tiles
            return result;
        }


    }
}