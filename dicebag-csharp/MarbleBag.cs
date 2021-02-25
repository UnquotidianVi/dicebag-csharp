namespace Dicebag {

    /// <summary> A bag of green (success) and red (fail) "marbles" that you can draw from. </summary>
    public class MarbleBag
    {
        private int successCount;
        private int failCount;
        private int fullSuccessCount;
        private int fullFailCount;
        private bool resetOnSuccess;

        /// <summary> Create a bag of green (success) and red (fail) "marbles" that you can draw from. 
        /// If reset_on_success is true, the bag will be reset after the first green (success) marble is drawn, 
        /// otherwise the bag will reset when all marbles have been drawn.</summary>
        public MarbleBag(int _successCount, int _failCount, bool _resetOnSuccess)
        {
            successCount = _successCount;
            fullSuccessCount = _successCount;
            failCount = _failCount;
            fullFailCount = _failCount;
            resetOnSuccess = _resetOnSuccess;
        }

        /// <summary> Draw a marble from marble bag. Returns true or false. </summary>
        public bool DrawAMarbleFromBag()
        {
            if(Dicebag.R.Next(0, successCount + failCount) < successCount)
            {
                if(resetOnSuccess)
                    ResetBag();
                else
                    successCount--;
                return true;
            }
            
            failCount--;
            return false;
        }

        /// <summary> Fill bag with marbles </summary>
        public void ResetBag()
        {
            successCount = fullSuccessCount;
            failCount = fullFailCount;
        }
    }
}