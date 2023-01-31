using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, int> items = new Dictionary<string, int>();
            //items.Add("Shadowmourne", 0);
            //items.Add("Valanyr", 0);
            //items.Add("Dragonwrath", 0);
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);
            Dictionary<string, int> junk = new Dictionary<string, int>();
            while (keyMaterials.Values.All(x => x < 250))
            {
                string[] materials = Console.ReadLine().Split();
                for (int i = 0; i < materials.Length; i += 2)
                {
                    int quantity = int.Parse(materials[i]);
                    string material = materials[i + 1].ToLower();
                    if (material == "shards")
                    {
                        keyMaterials["shards"] += quantity;
                    }
                    else if (material == "fragments")
                    {
                        keyMaterials["fragments"] += quantity;
                    }
                    else if (material == "motes")
                    {
                        keyMaterials["motes"] += quantity;
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk.Add(material, 0);
                        }
                        junk[material] += quantity;
                    }
                    if (keyMaterials.Values.Any(x => x >= 250))
                    {
                        break;
                    }
                }
            }
            if (keyMaterials["shards"] >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                keyMaterials["shards"] -= 250;
            }
            else if (keyMaterials["fragments"] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                keyMaterials["fragments"] -= 250;
            }
            else if (keyMaterials["motes"] >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                keyMaterials["motes"] -= 250;
            }
            foreach (var item in keyMaterials.OrderByDescending(n => n.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var junks in junk.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{junks.Key}: {junks.Value}");
            }
            //3 Motes 5 stones 5 Shards 6 leathers 255 fragments 7 Shards
        }
    }
}
