﻿namespace TexasHoldem.Tests.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using TexasHoldem.Logic;
    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Extensions;
    using TexasHoldem.Logic.Helpers;

    public class HandEvaluatorTests
    {
        // TODO: Add more tests for GetRankType()
        private static readonly object[] GetRankTypeCases =
            {
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Spade, CardType.King),
                                new Card(CardSuit.Spade, CardType.Seven),
                                new Card(CardSuit.Heart, CardType.Six),
                                new Card(CardSuit.Spade, CardType.Five),
                                new Card(CardSuit.Club, CardType.Three),
                                new Card(CardSuit.Diamond, CardType.Two)
                            },
                        HandRankType.HighCard, new List<Card> { }
                    },
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Spade, CardType.King),
                                new Card(CardSuit.Spade, CardType.Seven),
                                new Card(CardSuit.Heart, CardType.Six),
                                new Card(CardSuit.Spade, CardType.Six),
                                new Card(CardSuit.Club, CardType.Three),
                                new Card(CardSuit.Diamond, CardType.Two)
                            },
                        HandRankType.Pair, new List<Card> { }
                    },
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Spade, CardType.Seven),
                                new Card(CardSuit.Heart, CardType.Seven),
                                new Card(CardSuit.Heart, CardType.Six),
                                new Card(CardSuit.Spade, CardType.Six),
                                new Card(CardSuit.Club, CardType.Three),
                                new Card(CardSuit.Diamond, CardType.Two)
                            },
                        HandRankType.TwoPairs, new List<Card> { }
                    },
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Spade, CardType.King),
                                new Card(CardSuit.Spade, CardType.Six),
                                new Card(CardSuit.Heart, CardType.Six),
                                new Card(CardSuit.Club, CardType.Six),
                                new Card(CardSuit.Club, CardType.Three),
                                new Card(CardSuit.Diamond, CardType.Two)
                            },
                        HandRankType.ThreeOfAKind, new List<Card> { }
                    },
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Spade, CardType.Two),
                                new Card(CardSuit.Spade, CardType.Three),
                                new Card(CardSuit.Heart, CardType.Four),
                                new Card(CardSuit.Spade, CardType.Five),
                                new Card(CardSuit.Club, CardType.Jack),
                                new Card(CardSuit.Diamond, CardType.Queen)
                            },
                        HandRankType.Straight, new List<Card> { }
                    },
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Spade, CardType.King),
                                new Card(CardSuit.Spade, CardType.Queen),
                                new Card(CardSuit.Heart, CardType.Jack),
                                new Card(CardSuit.Spade, CardType.Ten),
                                new Card(CardSuit.Club, CardType.Seven),
                                new Card(CardSuit.Diamond, CardType.Three)
                            },
                        HandRankType.Straight, new List<Card> { }
                    },
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Spade, CardType.King),
                                new Card(CardSuit.Spade, CardType.Queen),
                                new Card(CardSuit.Heart, CardType.Jack),
                                new Card(CardSuit.Spade, CardType.Ten),
                                new Card(CardSuit.Club, CardType.Seven),
                                new Card(CardSuit.Spade, CardType.Three)
                            },
                        HandRankType.Flush, new List<Card> { }
                    },
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Spade, CardType.King),
                                new Card(CardSuit.Spade, CardType.Queen),
                                new Card(CardSuit.Heart, CardType.Ten),
                                new Card(CardSuit.Spade, CardType.Nine),
                                new Card(CardSuit.Club, CardType.Seven),
                                new Card(CardSuit.Spade, CardType.Three)
                            },
                        HandRankType.Flush, new List<Card> { }
                    },
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Spade, CardType.King),
                                new Card(CardSuit.Spade, CardType.Queen),
                                new Card(CardSuit.Spade, CardType.Ten),
                                new Card(CardSuit.Spade, CardType.Nine),
                                new Card(CardSuit.Spade, CardType.Seven),
                                new Card(CardSuit.Spade, CardType.Three)
                            },
                        HandRankType.Flush, new List<Card> { }
                    },
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Heart, CardType.Ace),
                                new Card(CardSuit.Club, CardType.Ace),
                                new Card(CardSuit.Diamond, CardType.Ten),
                                new Card(CardSuit.Club, CardType.Ten),
                                new Card(CardSuit.Club, CardType.Seven),
                                new Card(CardSuit.Spade, CardType.Three)
                            },
                        HandRankType.FullHouse, new List<Card> { }
                    },
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Heart, CardType.Ace),
                                new Card(CardSuit.Club, CardType.Ace),
                                new Card(CardSuit.Diamond, CardType.Ace),
                                new Card(CardSuit.Club, CardType.Ten),
                                new Card(CardSuit.Club, CardType.Seven),
                                new Card(CardSuit.Spade, CardType.Three)
                            },
                        HandRankType.FourOfAKind, new List<Card> { }
                    },
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Spade, CardType.Two),
                                new Card(CardSuit.Spade, CardType.Three),
                                new Card(CardSuit.Spade, CardType.Four),
                                new Card(CardSuit.Spade, CardType.Five),
                                new Card(CardSuit.Diamond, CardType.Eight),
                                new Card(CardSuit.Heart, CardType.Jack),
                                new Card(CardSuit.Club, CardType.Queen)
                            },
                        HandRankType.StraightFlush, new List<Card> { }
                    },
                new object[]
                    {
                        new[]
                            {
                                new Card(CardSuit.Spade, CardType.Ace),
                                new Card(CardSuit.Spade, CardType.Two),
                                new Card(CardSuit.Spade, CardType.Three),
                                new Card(CardSuit.Spade, CardType.Four),
                                new Card(CardSuit.Spade, CardType.Five),
                                new Card(CardSuit.Spade, CardType.Eight),
                                new Card(CardSuit.Spade, CardType.Jack),
                                new Card(CardSuit.Spade, CardType.Queen)
                            },
                        HandRankType.StraightFlush, new List<Card> { }
                    },
            };

        [Test]
        [TestCaseSource(nameof(GetRankTypeCases))]
        public void GetRankTypeShouldWorkCorrectly(ICollection<Card> playerCards, HandRankType expectedHandRankType, ICollection<Card> expectedBestHandCards)
        {
            var handEvaluator = new HandEvaluator();
            var bestHand = handEvaluator.GetBestHand(playerCards.Shuffle().ToList());
            Assert.AreEqual(expectedHandRankType, bestHand.RankType);
            CollectionAssert.AreEquivalent(expectedBestHandCards, bestHand.Cards);
        }
    }
}
