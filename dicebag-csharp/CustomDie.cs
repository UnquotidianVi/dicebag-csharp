namespace Dicebag.Die
{
    public struct CustomDie
    {
        public CustomDie(DieSide[] _sides)
        {
            Sides = _sides;
        }

        public DieSide[] Sides { get; }
    }

    public struct DieSide
    {
        public DieSide(int _weight, int _value)
        {
            W = _weight;
            V = _value;
        }

        public float W { get; }
        public int V { get; }
    }
}