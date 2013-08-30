using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using Microsoft.Ajax.Utilities;

namespace MyMetroApp.MetroUIMvc
{
    public class MetroTile
    {
        // Base set of properties
        private readonly string id;
        public TileType TileType;
        public int Column;
        public int Width;
        public int Height;
        public int LeftMargin = 0;
        public int TopMargin = 0;
        public string BgColor;
        public string Title;
        public string LabelText;
        public string LabelColor;
        public string LabelPosition;
        public string Classes;
        public string NavUrl;
        public string OnClick;

        // Used for a Scrolling Text Tile
        public List<string> Text = new List<string>();
        public int ScrollSpeed = 5000;

        // Used for an Image Tile
        public string ImgUrl;
        public string ImgAlt;
        public string ImgTitle;
        public string ImgDesc;
        public bool ShowImgDescAlways = true;

        public int ImgHeight = 50;
        public int ImgWidth = 50;
        public int ImgToTop = 5;
        public int ImgToLeft = 5;


        // Initialize our tile, basic common settings
        // To make it more flexible, all other specialized properties are set on specific properties
        public MetroTile(int column, TileType tileType, int topMargin, int leftMargin, TileWidth width,
            TileHeight height, string bgColor, string title, string onClick = "", string navUrl = "")
        {
            this.LeftMargin = leftMargin;
            this.TopMargin = topMargin;
            this.Width = (int) width;
            this.Height = (int) height;
            this.BgColor = bgColor;
            this.OnClick = onClick;
            this.Column = column;
            this.TileType = tileType;
            this.Title = title;
            this.NavUrl = navUrl;
            this.id = (this.Column + "_" + this.TopMargin + "-" + this.LeftMargin).ToString();
        }

        // Get the Html for this tile, based on other methods
        public string GetHtml()
        {
            string result = "";
            result = GetTileHtml() + GetImageHtml() + GetTitleHtml() + GetTextHtml() + GetLabelHtml() + "</a>";

            return result;
        }


        private string GetTileHtml()
        {
            string result = "";
            string navUrlValue = "";
            string onClickValue = "";

            // Is there a nav url
            if (!this.NavUrl.IsNullOrWhiteSpace())
                navUrlValue = string.Format("href=\"{0}\"", this.NavUrl);

            // Is there an onclick
            if (!this.OnClick.IsNullOrWhiteSpace())
                onClickValue = string.Format("onclick=\"{0}\"", this.OnClick);


            // What type of tile shall we create
            switch (this.TileType)
            {
                case TileType.Simple:
                    result = "<a {8} class=\"tile group{1} {9}\" " +
                             "style=\"margin-top: {2}px; margin-left: {3}px; width: {4}px; " +
                             "height: {5}px; background: {6};\" data-pos=\"{2}-{3}-{4}\" {7}>";

                    break;

                case TileType.ScrollingText:
                    result = "<a {8} id=\"tileScroll{0}\" class=\"tile tileScroll group{1} {9}\" " +
                             "style=\"margin-top: {2}px; margin-left: {3}px; width: {4}px; " +
                             "height: {5}px; background: {6};\" data-pos=\"{2}-{3}-{4}\" {7}>";

                    break;

                case TileType.Image:
                    result = "<a {8} class=\"tile group{1} {9}\" " +
                             "style=\"margin-top: {2}px; margin-left: {3}px; width: {4}px; " +
                             "height: {5}px; background: {6};\" data-pos=\"{2}-{3}-{4}\" {7}>";

                    break;

                default:

                    break;
            }

            // Format the basic tile
            result = string.Format(result,
                this.id,
                this.Column,
                this.TopMargin,
                this.LeftMargin,
                this.Width,
                this.Height,
                this.BgColor,
                onClickValue,
                navUrlValue,
                this.Classes);

            return result;

        }

        private string GetImageHtml()
        {
            string result = "";

            if (!this.ImgUrl.IsNullOrWhiteSpace())
            {
                result = "<img style='float:left; margin-top:{0}px; margin-left:{1}px;' src='{2}' height={3} width={4} />";

                result = string.Format(result,
                    this.ImgToTop,
                    this.ImgToLeft,
                    this.ImgUrl,
                    this.ImgHeight,
                    this.ImgWidth);
            }

            return result;

        }

        private string GetTitleHtml()
        {
            string result = "";

            if (!this.Title.IsNullOrWhiteSpace())
            {
                int leftMargin = 12;

                if (!this.ImgUrl.IsNullOrWhiteSpace())
                {
                    leftMargin = (this.ImgWidth + this.ImgToLeft) + 12;
                }

                result = "<div class=\"tileTitle\" style=\"margin-left: {0}px;\">{1}</div>";

                result = string.Format(result,
                    leftMargin,
                    this.Title
                    );

            }

            return result;

        }

        private string GetTextHtml()
        {
            string result = "";

            if (this.Text.Count() > 0)
            {
                int leftMargin = 12;

                if (!this.ImgUrl.IsNullOrWhiteSpace())
                {
                    leftMargin = (this.ImgWidth + this.ImgToLeft) + 12;
                }

                if (TileType == TileType.ScrollingText)
                {
                    result = "<div class=\"divScroll\" style=\"margin-left: {0}px;\">{1}</div>" + 
                                "<script>scrollTile(\"{2}\", {3}, {4}, 0)</script>";
                    result = string.Format(result,
                        leftMargin,
                        this.Text[0],
                        this.id,
                        Json.Encode(this.Text),
                        this.ScrollSpeed);
                }
                else
                {
                    result = "<div class=\"tileDesc\" style=\"margin-left: {0}px;\">{1}</div>";

                    result = string.Format(result,
                        leftMargin,
                        this.Text[0]
                        );                    
                }
            }

            return result;
        }

        private string GetLabelHtml()
        {
            string result = "";

            if (!this.LabelText.IsNullOrWhiteSpace())
            {
                if (this.LabelPosition == "top")
                {
                    result = "<div class=\"tileLabelWrapper top\" style=\"border-top-color: {0};\"><div class=\"tileLabel top\">{1}</div></div>";
                }
                else
                {
                    result = "<div class=\"tileLabelWrapper bottom\"><div class=\"tileLabel bottom\" style=\"border-bottom-color: {0};\">{1}</div></div>";
                    
                }
                result = string.Format(result,
                    this.LabelColor,
                    this.LabelText
                    );
            }

            return result;
        }

    }
}

