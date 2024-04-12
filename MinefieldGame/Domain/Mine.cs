using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Domain
{
    public class Mine : IMine
    {
        private int _quantity;

        /// <inheritdoc>
        private string[] _positions;

        public int Quantity
        {
            get { return _quantity; }
        }
        public string[] Positions
        {
            get { return _positions; }
            set { _positions = value; }
        }

        public Mine(int quantity)
        {
            _quantity = quantity;
        }

        public bool IsMine(string position)
        {
            return _positions.Contains(position);
        }
    }
}
