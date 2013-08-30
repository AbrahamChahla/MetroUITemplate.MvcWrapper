using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;

namespace MyMetroApp.MetroUIMvc
{
    public class MetroScreen
    {
        public int Scale = 145;
        public int Spacing = 10;
        public int GroupSpacing = 290;
        public string ThemePath = "theme_default";
        public int InactiveOpacity = 1;
        public int GroupInactiveClickable = 1;
        public int GroupShowEffect = 2;
        public string GroupDirection = "horizontal";
        public int MouseScroll = 1;
        public string SiteTitle = "My Site";
        public string SiteTitleHome = "Home";
        public int ShowSpeed = 400;
        public int HideSpeed = 300;
        public int ScrollSpeed = 550;
        public string Device = "desktop";
        public int ScrollHeader = 1 ;
        public int DisableGroupScrollingWhenVerticalScroll = 0;
        public int BgMaxScroll = 130;
        public int BgScrollSpeed = 450;
        public int AutoRearrangeTiles = 1;
        public int AutoResizeTiles = 1;
        public int RearrangeThreshhold = 3;


        public int SpacingBetweenColumns;
        public int SpacingBetweenTiles;

        public int TilesStartTopMargin;
        public int TilesStartLeftMargin;
        
        public List<MetroColumn> Columns;

        
        // Most basic... you would need to then set the properties individually
        public MetroScreen()
        {
            // Always will need a list object to hold our columns
            this.Columns = new List<MetroColumn>();
        }


        // This will be the one used most, allows creating a basic screen in one swoop
        public MetroScreen(int spacingBetweenColumns, int spacingBetweenTiles, int tilesStartLeftMargin, int tilesStartTopMargin)
        {
            this.SpacingBetweenColumns = spacingBetweenColumns;
            this.SpacingBetweenTiles = spacingBetweenTiles;
            this.TilesStartTopMargin = tilesStartTopMargin;
            this.TilesStartLeftMargin = tilesStartLeftMargin;

            // Always will need a list object to hold our columns
            this.Columns = new List<MetroColumn>();
        }


        // Add a column to the screen, both parameters are optional
        public MetroColumn AddColumn(string title = "", string onClick = "") 
        {
            // Create the column
            MetroColumn newColumn = new MetroColumn(this, title, onClick);

            // Add the column to columns list
            this.Columns.Add(newColumn);

            // Return the column so it can be worked with
            return newColumn;
        }

        // This messy method is used to create the client side variables
        // used in configuring the MetroUI "engine"
        public string GetClientConfig()
        {
            string result = "";
            List<string> titles = new List<string>();
            List<double> groupSpacing = new List<double>();

            foreach (MetroColumn column in this.Columns)
            {
                titles.Add(column.TitleText);
                groupSpacing.Add(2.87);
            }

            result += ("<script>");
            result += ("scale=" + this.Scale + ";");
            result += ("spacing=" + this.Spacing + ";");
            result += ("theme=\"" + this.ThemePath + "\";");
            result += ("$group.titles=" + Json.Encode(titles) + ";");
            result += ("$group.spacingFull=" + Json.Encode(groupSpacing) + ";");
            result += ("$group.inactive.opacity=\"" + this.InactiveOpacity + "\";");
            result += ("$group.inactive.clickable=\"" + this.GroupInactiveClickable + "\";");
            result += ("$group.showEffect=" + this.GroupShowEffect + ";");
            result += ("$group.direction=\"" + this.GroupDirection + "\";");
            result += ("mouseScroll=\"" + this.MouseScroll + "\";");
            result += ("siteTitle=\"" + this.SiteTitle + "\";");
            result += ("siteTitleHome=\"" + this.SiteTitleHome + "\";");
            result += ("showSpeed=" + this.ShowSpeed + ";");
            result += ("hideSpeed=" + this.HideSpeed + ";");
            result += ("scrollSpeed=" + this.ScrollSpeed + ";");
            result += ("device=\"" + this.Device + "\";");
            result += ("scrollHeader=\"" + this.ScrollHeader + "\";");
            result += ("disableGroupScrollingWhenVerticalScroll=\"" + this.DisableGroupScrollingWhenVerticalScroll + "\";");
            result += ("bgMaxScroll=\"" + this.BgMaxScroll + "\";");
            result += ("bgScrollSpeed=\"" + this.BgScrollSpeed + "\";");
            result += ("autoRearrangeTiles=\"" + this.AutoRearrangeTiles + "\";");
            result += ("autoResizeTiles=\"" + this.AutoResizeTiles + "\";");
            result += ("rearrangeTreshhold=" + this.RearrangeThreshhold + ";");
            result += ("</script>");

            return result;
        }

        
    }
}