using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.moririring
{
    public class PatternDataRom
    {

        static readonly private string[, ,] PatternRiver = new string[2, 1, 1]
    {
        {
            { "block_bule" },
        },
        {
            { "block_bule" },
        }
    };


        static readonly public string[, ,] PatternTree = new string[1, 1, 2]
    {
        {
            { "block_brown", "block_green" },
        },
    };
        static readonly private string[, ,] PatternSea = new string[3, 3, 1]
    {
        {
            { "block_bule" },{ "block_bule" },{ "block_bule" }
        },
        {
            { "block_bule" },{ "block_bule" },{ "block_bule" }
        },
        {
            { "block_bule" },{ "block_bule" },{ "block_bule" }
        },
    };
        static readonly private string[, ,] PatternGreen = new string[2, 2, 1]
    {
        {
            { "block_green" },{ "block_green" }
        },
        {
            { "block_green" },{ "block_green" }
        },
    };

        static readonly private string[, ,] PatternHouse = new string[1, 1, 2]
    {
        {
            { "block_white", "block_red" },
        },
    };

        static readonly private string[, ,] PatternCastle = new string[3, 1, 2]
    {
        {
            { "block_white",  "block_white" },
        },
        {
            { "block_white",  "" },
        },
        {
            { "block_white",  "block_white" },
        }
    };
        static readonly private string[, ,] PatternMoutain = new string[3, 3, 2]
    {
        {
            { "block_brown","" },{ "block_brown","" },{ "block_brown","" }
        },
        {
            { "block_brown","" },{ "block_brown","block_brown" },{ "block_brown","" }
        },
        {
            { "block_brown","" },{ "block_brown","" },{ "block_brown","" }
        },
    };

        static readonly public PatternData[] PatternDatas = new[]
    {
        new PatternData()
        {
            name = "木",
            PaternArray = PatternTree,
            OneCheck = true,
            x = 1,
            y = 1,
            z = 2,
        },
        new PatternData()
        {
            name = "川",
            PaternArray = PatternRiver,
            OneCheck = false,
            x = 2,
            y = 1,
            z = 1,
        },
        new PatternData()
        {
            name = "海",
            PaternArray = PatternSea,
            OneCheck = false,
            x = 3,
            y = 3,
            z = 1,
        },
        new PatternData()
        {
            name = "草",
            PaternArray = PatternGreen,
            OneCheck = false,
            x = 2,
            y = 2,
            z = 1,
        },
        new PatternData()
        {
            name = "家",
            PaternArray = PatternHouse,
            OneCheck = true,
            x = 1,
            y = 1,
            z = 2,
        },
        new PatternData()
        {
            name = "城",
            PaternArray = PatternCastle,
            OneCheck = true,
            x = 3,
            y = 1,
            z = 2,
        },
        new PatternData()
        {
            name = "山",
            PaternArray = PatternMoutain,
            OneCheck = true,
            x = 3,
            y = 3,
            z = 2,
        },
    };

    }
}
