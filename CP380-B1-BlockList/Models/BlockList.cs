using System;
using System.Collections.Generic;

namespace CP380_B1_BlockList.Models
{
    public class BlockList
    {
        public IList<Block> Chain { get; set; }

        public int Difficulty { get; set; } = 2;

        public BlockList()
        {
            Chain = new List<Block>();
            MakeFirstBlock();
        }

        public void MakeFirstBlock()
        {
            var block = new Block(DateTime.Now, null, new List<Payload>());
            block.Mine(Difficulty);
            Chain.Add(block);
        }

       public void AddBlock(Block b)
        {
            Block va = GetBlock();
            b.Nonce = va.Nonce + 1;
            b.PreviousHash = va.Hash;
            b.Mine(this.Difficulty);
            Chain.Add(b);
        }

        public Block GetBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public bool IsValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block current = Chain[i];
                Block pr = Chain[i - 1];

                if (current.Hash != current.CalculateHash())
                {
                    return false;
                }

                if (current.PreviousHash != pr.Hash)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
