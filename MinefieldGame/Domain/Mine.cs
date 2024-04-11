using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Domain
{
    public class Mine : IMine
    {
        private readonly string[] positions;

        public Mine(string[] positions)
        {
            this.positions = positions;
        }

        public bool IsMine(string position)
        {
            return positions.Contains(position);
        }
    }
}
