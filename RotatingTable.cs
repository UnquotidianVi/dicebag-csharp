namespace Dicebag
{
    /// <summary>A rollable table where entries are removed as they are rolled.</summary>
    public class RotatingTable
    {
        private RotatingTableItem[] originalTableItems;
        private RotatingTableItem[] currentTableItems;

        /// <summary>Create a rollable table where entries are removed as they are rolled.</summary>
        public RotatingTable(RotatingTableItem[] _tableItems)
        {
            originalTableItems = new RotatingTableItem[_tableItems.Length];
            currentTableItems = new RotatingTableItem[_tableItems.Length];

            for(int i = 0; i < _tableItems.Length; i++)
            {
                originalTableItems[i] = _tableItems[i];
                currentTableItems[i] = _tableItems[i];
            }
        }

        /// <summary>Roll a value from a rollable table. Returns the value specified in the table.</summary>
        public int RotateTable()
        {
            float totalWeight = 0;
            for(int i = 0; i < currentTableItems.Length; i++)
                totalWeight += currentTableItems[i].Weight;
            
            float weightResult = (float)Dicebag.R.Next(0, 100) / 100 * totalWeight;

            float processedWeight = 0;
            for(int i = 0; i < currentTableItems.Length; i++)
            {
                processedWeight += currentTableItems[i].Weight;
                if(weightResult <= processedWeight)
                {
                    int result = currentTableItems[i].Value;

                    if(currentTableItems[i].ResetOnRoll || currentTableItems.Length == 1)
                    {
                        ResetTable();
                    }
                    else
                    {
                        RotatingTableItem[] oldCurrentTableItems = currentTableItems;
                        currentTableItems = new RotatingTableItem[oldCurrentTableItems.Length - 1];
                        
                        int currentTableItemsIndexToAddTo = 0;
                        for(int o = 0; o < oldCurrentTableItems.Length; o++)
                        {
                            if(o != i)
                            {
                                currentTableItems[currentTableItemsIndexToAddTo] = oldCurrentTableItems[o];
                                currentTableItemsIndexToAddTo++;
                            }
                        }
                    }

                    return result;
                }
            }
            return 0;
        }

        /// <summary>Reset table's items to the original ones</summary>
        public void ResetTable()
        {
            currentTableItems = new RotatingTableItem[originalTableItems.Length];
            for(int i = 0; i < originalTableItems.Length; i++)
                currentTableItems[i] = originalTableItems[i];
        }
    }

    public struct RotatingTableItem{
        public RotatingTableItem(float _weight, int _value, bool _resetOnRoll)
        {
            Weight = _weight;
            Value = _value;
            ResetOnRoll = _resetOnRoll;
        }

        public float Weight { get; }
        public int Value { get; }
        public bool ResetOnRoll { get; }
    }
}
