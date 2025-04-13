namespace Challenges
{
    public class Pack
    {
        #region Base Class Properties
        public int BagItemCapacity { get; protected set; }
        public float BagWeightCapacity { get; protected set; }
        public float BagVolumeCapacity { get; protected set; }
        public List<InventoryItem> PackInventoryList { get; protected set; }

        #endregion
        public Pack(int itemCapacity, int weightCapacity, int volumeCapacity)
        {
            BagItemCapacity = itemCapacity;
            BagWeightCapacity = weightCapacity;
            BagVolumeCapacity = volumeCapacity;
            PackInventoryList = new List<InventoryItem>();
        }
        public override string ToString()
        {
            string itemList = string.Empty;

            for (int i = 1; i < PackInventoryList.Count; i++)
            {
                itemList += $"{i}: {PackInventoryList[i].ToString()} ";
            }
            if (itemList == string.Empty)
            {
                itemList = "Pack is empty";
            }
            return itemList;
        }

        public bool PackItem(InventoryItem item)
        {
            if (item.ItemWeight > BagWeightCapacity)
            {
                Console.WriteLine($"Overweight, {item} can not be added.");
                return false;
            }
            else if (item.ItemVolume > BagVolumeCapacity)
            {
                Console.WriteLine($"Overvolume, {item} can not be added.");
                return false;
            }
            else if (BagItemCapacity <= 0)
            {
                Console.WriteLine($"Over Item Capacity, {item} can not be added.");
                return false;
            }
            else
            {
                BagItemCapacity -= 1;
                BagWeightCapacity -= item.ItemWeight;
                BagVolumeCapacity -= item.ItemVolume;

                Console.WriteLine();
                Console.WriteLine($"Item Added: {item.ToString()}");
                PackInventoryList.Add(item);
                PackStatus();

                return true;
            }
        }

        public void PackItems(params InventoryItem[] items)
        {
            foreach (InventoryItem item in items)
            {
                PackItem(item);
            }
        }

        public Pack CreateNewPack() // not finished implementing but i get the jist of the challenge on 205 so i probably wont finish this class in full.
        {
            return new Pack(10, 8, 4);
        }

        public void PackStatus()
        {
            Console.WriteLine($"PACK STATUS | Item Capacity Left: {BagItemCapacity}, Weight Capacity Left: {BagWeightCapacity:.##}, Volume Capacity Left: {BagVolumeCapacity:.##}");
        }
    }

    public abstract class InventoryItem
    {
        public string ItemName { get; set; }
        public float ItemWeight { get; set; }
        public float ItemVolume { get; set; }
        public InventoryItem()
        {

        }

        public override string ToString()
        {
            return $"{ItemName}";
        }
    }

    public class ArrowItem : InventoryItem
    {
        public ArrowItem()
        {
            ItemName = "Arrow";
            ItemWeight = 0.1f;
            ItemVolume = 0.05f;
        }
    }

    public class BowItem : InventoryItem
    {
        public BowItem()
        {
            ItemName = "Bow";
            ItemWeight = 1.0f;
            ItemVolume = 4.0f;
        }
    }

    public class RopeItem : InventoryItem
    {
        public RopeItem()
        {
            ItemName = "Rope";
            ItemWeight = 1.0f;
            ItemVolume = 1.5f;
        }
    }

    public class WaterItem : InventoryItem
    {
        public WaterItem()
        {
            ItemName = "Water";
            ItemWeight = 2.0f;
            ItemVolume = 3.0f;
        }
    }

    public class FoodRationItem : InventoryItem
    {
        public FoodRationItem()
        {
            ItemName = "Food Ration";
            ItemWeight = 1.0f;
            ItemVolume = 0.5f;
        }
    }

    public class SwordItem : InventoryItem
    {
        public SwordItem()
        {
            ItemName = "Sword";
            ItemWeight = 5.0f;
            ItemVolume = 3.0f;
        }
    }
}
