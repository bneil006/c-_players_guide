namespace Challenges
{
    public class Arrows // challenge on page 154, 164, 168 and 173
    {
        #region Class Statics
        private readonly static List<Arrows> soldArrow = new List<Arrows>();
        public static Arrows CreateEliteArrow() => new Arrows("Steel", 95, "Plastic");
        public static Arrows CreateBeginnerArrow() => new Arrows("Wood", 75, "Goose");
        public static Arrows CreateMarksmanArrow() => new Arrows("Obsidian", 65, "Turkey");

        public static void SoldArrowLedger()
        {
            for (int i = 0; i < soldArrow.Count; i++)
            {
                Console.WriteLine($"Head: {soldArrow[i].Head}, Fletching: {soldArrow[i].Fletching}, Length: {soldArrow[i].ShaftLength}, Cost: {soldArrow[i].Cost}");
            }
        }
        #endregion

        #region Instance Fields
        private string head;
        private string fletching;
        private float shaftLength;
        #endregion

        #region Properties
        public string Head // began working on properties for better getters and setters vs creating your own class methods
        {
            get { return head; }
            set { head = value.ToUpper(); }
        }

        public string Fletching
        {
            get { return fletching; }
            set { fletching = value.ToUpper(); }
        }

        public float ShaftLength
        {
            get { return shaftLength; }
            set { shaftLength = Math.Clamp(value, 60.0f, 100.0f); }
        }

        public float Cost
        {
            get
            {
                float headCost;
                float fletchingCost;
                float lengthCost;

                headCost = Head switch
                {
                    "STEEL" => 10.0f,
                    "WOOD" => 3.0f,
                    "OBSIDIAN" => 5.0f,
                    _ => throw new Exception($"Invalid selection: {Head}, Choose [Steel, Wood, Obsidian]")
                };

                fletchingCost = Fletching switch
                {
                    "PLASTIC" => 10.0f,
                    "TURKEY" => 5.0f,
                    "GOOSE" => 3.0f,
                    _ => throw new Exception($"Invalid selection: {Fletching}, Choose [Plastic, Turkey, Goose]")
                };

                lengthCost = 0.05f * ShaftLength;

                return headCost + fletchingCost + lengthCost;
            }
        }
        #endregion

        #region Constructors
        public Arrows() : this("STEEL", 60, "PLASTIC")
        {
            
        }

        public Arrows(string head, float shaftLength, string fletching)
        {
            Head = head;
            Fletching = fletching;
            ShaftLength = shaftLength;
            soldArrow.Add(this);
        }
        #endregion
    }
}