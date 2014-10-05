using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BMRF.Domain.DataModels;
using BMRF.Domain.Exceptions;

namespace BMRF.Domain
{
    public class Inventory
    {
        private readonly string _inventoryString;

        private string _items;

        public Item PrimaryWeapon { get; private set; }
        public Item SecondaryWeapon { get; private set; }
        public Item Backpack { get; private set; }
        public List<Item> Items { get; private set; }
        public List<Item> Optics { get; private set; }
        public List<Item> Tools { get; private set; }

        public Inventory(string inventoryString)
        {
            _inventoryString = inventoryString;
            Items = new List<Item>();
            Optics = new List<Item>();
            Tools = new List<Item>();

            ParseInventoryString();
        }

        private void ParseInventoryString()
        {
            // split the items into categories, weapon and magazine
            // NEW REGEX: (?:\[\[(?<weapons>.*)\],\[(?<items>\[.*\])\]\])|(?:\[\[(?<weapons>[^\]]*)\],\[(?<items>.*)\]\])
            var categorySplitRegex = new Regex(@"(?:\[\[(?<weapons>.*)\],\[(?<items>\[.*\])\]\])|(?:\[\[(?<weapons>[^\]]*)\],\[(?<items>.*)\]\])");

            // split the items inside categories
            var itemSplitRegex = new Regex(@"([\""\w_]+)");

            if (_inventoryString == "[]") return;

            var regexMatch = categorySplitRegex.Match(_inventoryString);

            if (regexMatch.Success)
            {
                _items = regexMatch.Groups["weapons"].Value;
                if (!String.IsNullOrWhiteSpace(_items))
                    _items += "," + regexMatch.Groups["items"].Value;
                _items += regexMatch.Groups["items"].Value;
            }
            else
            {
                throw new InventoryParseException("Inventory string did not match the regular expression.");
            }


            using (var itemDatabase = new ItemsDataModel())
            {
                if (_items == null) return;

                var matchList = itemSplitRegex.Matches(_items);

                var playerItems = matchList.Cast<Match>().Select(match => match.Value).ToList();
                playerItems = playerItems.Select(str=>str.Replace("\"","")).ToList();

                foreach (string playerItem in playerItems)
                {
                    var item = (from i in itemDatabase.Items
                        where i.Class.ToLower() == playerItem.ToLower()
                        select i).FirstOrDefault();

                    if (item == null)
                        continue;

                    var newItem = new Item(item.Name, item.Subtitle, item.Description, item.Class, item.Image);
                    switch (item.Category)
                    {
                        case "Primary":
                            this.PrimaryWeapon = newItem;
                            break;
                        case "Secondary":
                            this.SecondaryWeapon = newItem;
                            break;
                        case "Backpack":
                            this.Backpack = newItem;
                            break;
                        case "Item":
                            this.Items.Add(newItem);
                            break;
                        case "Optic":
                            this.Optics.Add(newItem);
                            break;
                        case "Tool":
                            this.Tools.Add(newItem);
                            break;
                    }
                }
            }
        }
    }

    public class Item
    {
        /// <summary>
        /// Friendly name for the item.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The subtitle for the item, usually its type.
        /// </summary>
        public string Subtitle { get; private set; }
        /// <summary>
        /// The friendly description for the item.
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        ///  The Arma class name for the item.
        /// </summary>
        public string ClassName { get; private set; }
        /// <summary>
        /// The image name associated with the item.
        /// </summary>
        public string ImageName { get; private set; }

        public Item(string name, string subtitle, string description, string className, string imageName)
        {
            Name = name;
            Subtitle = subtitle;
            Description = description;
            ClassName = className;
            ImageName = imageName;
        }
    }
}
