using NecroLib.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Buildings.BuildingBuilder
{
    public abstract class BuildingBuilder
    {
        protected virtual int MIN_LEVEL { get; }
        protected virtual int MAX_LEVEL { get; }

        protected readonly Dictionary<int, int> DEFAULT_MAX_IMPROVEMENTS = new Dictionary<int, int>()
        {
            [1] = 2,
            [2] = 2,
            [3] = 3,
            [4] = 3,
            [5] = 4,
            [6] = 4,
            [7] = 5,
            [8] = 5,
        };

        protected readonly Dictionary<int, IPrice> DEFAULT_MINING_BASE_PRICES = new Dictionary<int, IPrice>()
        {
            [1] = new Price(250, 5000, 0, 0, 0),
            [2] = new Price(700, 15000, 0, 0, 0),
            [3] = new Price(1150, 21000, 0, 0, 0),
            [4] = new Price(2250, 37125, 0, 0, 0),
            [5] = new Price(2750, 48000, 0, 0, 0),
            [6] = new Price(4950, 90000, 0, 0, 1500),
            [7] = new Price(6250, 127500, 0, 0, 2100),
            [8] = new Price(12250, 257250, 0, 0, 4250),
        };
        protected readonly Dictionary<int, IPrice> DEFAULT_MINING_INCREMENT_PRICES = new Dictionary<int, IPrice>()
        {
            [1] = new Price(50, 1250, 0, 0, 0),
            [2] = new Price(150, 3000, 0, 0, 0),
            [3] = new Price(200, 4000, 0, 0, 0),
            [4] = new Price(280, 5625, 0, 0, 0),
            [5] = new Price(300, 6000, 0, 0, 0),
            [6] = new Price(440, 9375, 0, 0, 150),
            [7] = new Price(500, 11250, 0, 0, 190),
            [8] = new Price(875, 17500, 0, 0, 315),
        };

        protected readonly Dictionary<int, IPrice> DEFAULT_MILITARY_BASE_PRICES = new Dictionary<int, IPrice>()
        {
            [1] = new Price(250, 5000, 1500, 0, 0),
            [2] = new Price(700, 15000, 4200, 0, 0),
            [3] = new Price(1150, 21000, 5700, 0, 0),
            [4] = new Price(2250, 37125, 9950, 0, 0),
            [5] = new Price(2750, 48000, 12450, 0, 0),
            [6] = new Price(4950, 90000, 22300, 0, 1500),
            [7] = new Price(6250, 127500, 29800, 0, 2100),
            [8] = new Price(12250, 257250, 56175, 0, 4250),
        };
        protected readonly Dictionary<int, IPrice> DEFAULT_MILITARY_INCREMENT_PRICES = new Dictionary<int, IPrice>()
        {
            [1] = new Price(50, 1250, 300, 0, 0),
            [2] = new Price(150, 3000, 750, 0, 0),
            [3] = new Price(200, 4000, 1050, 0, 0),
            [4] = new Price(280, 5625, 1350, 0, 0),
            [5] = new Price(300, 6000, 1350, 0, 0),
            [6] = new Price(440, 9375, 1875, 0, 150),
            [7] = new Price(500, 11250, 2050, 0, 190),
            [8] = new Price(875, 17500, 3150, 0, 315),
        };

        protected Dictionary<int, int> _maxImprovements;

        protected Dictionary<int, IPrice> _basePrices;

        protected Dictionary<int, IPrice> _incrementPrices;

        protected void FillData(Dictionary<int, int> maxImpovements, Dictionary<int, IPrice> basePrices, Dictionary<int, IPrice> incrementPrices)
        {
            _maxImprovements = new Dictionary<int, int>();
            foreach (var improvements in maxImpovements)
            {
                if (improvements.Key >= MIN_LEVEL && improvements.Key <= MAX_LEVEL)
                    _maxImprovements.Add(improvements.Key, improvements.Value);
            }
            _basePrices = new Dictionary<int, IPrice>();
            foreach (var prices in basePrices)
            {
                if (prices.Key >= MIN_LEVEL && prices.Key <= MAX_LEVEL)
                    _basePrices.Add(prices.Key, prices.Value);
            }
            _incrementPrices = new Dictionary<int, IPrice>();
            foreach (var prices in incrementPrices)
            {
                if (prices.Key >= MIN_LEVEL && prices.Key <= MAX_LEVEL)
                    _incrementPrices.Add(prices.Key, prices.Value);
            }
        }
    }
}
