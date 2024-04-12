namespace MinefieldGame.Domain
{
    public interface IMine
    {

        /// <summary>
        /// Number of mines required
        /// </summary>
        int Quantity { get; }

        /// <summary>
        /// Returns the location of mines.
        /// </summary>
        string[] Positions { get; }

        /// <summary>
        /// Indicates a mine is at a given location.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        bool IsMine(string position);

    }
}