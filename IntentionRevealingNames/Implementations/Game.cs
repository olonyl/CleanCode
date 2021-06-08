using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntentionRevealingNames.Interfaces;

namespace IntentionRevealingNames.Implementations
{
    public class Game:IGame
    {
        private readonly IEnumerable<Cell> _gameBoard;

        public Game(IEnumerable<Cell> gameBoard)
        {
            _gameBoard = gameBoard?? throw  new ArgumentException(nameof(gameBoard));
        }
        public IEnumerable<Cell> GetFlaggedCells()
        {
            return _gameBoard.Where(x => x.IsFlagged()).Select(s=> s).ToList();
        }
    }
}
