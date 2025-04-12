namespace Challenges
{
    public class DominonOfKings
    {
        public int CalculateScore(int provinces, int duchies, int estates) // challenge on Page 55
        {
            int total = 0;
            total += estates;
            total += duchies * 3;
            total += provinces * 6;

            return total;
        }
    }
}
