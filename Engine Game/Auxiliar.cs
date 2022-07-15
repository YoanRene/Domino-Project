namespace Project
{
    static class Auxiliar
    {
        public static void ScoreCalculate(Func<int, int, bool> func, Game game)
        {
            double[] score = new double[game.Players.Count];
            for (int i = 0; i < game.Players.Count; i++)
                for (int j = 0; j < game.Players[i].Hand.Count; j++)
                {
                    if (func(i, j))
                        game.Players[i].ScoreGame += game.Players[i].Hand[j].Right + game.Players[i].Hand[j].Left;
                    game.Players[i].ScoreGame += game.Players[i].Hand[j].Right + game.Players[i].Hand[j].Left;
                }
        }
        public static List<Token> ValidTokensToPlay(List<Token> hand, IActionModeratorToAdd actionModeratorToAdd, IActionModeratorToSub actionModeratorToSub, Table table)
        {
            HashSet<Token> okPlayed = new HashSet<Token>();

            if (table.TokensInGame.Count == 0)
                return hand;

            for (int i = 0; i < hand.Count; i++)
                if (hand[i].Left == table.Left || hand[i].Left == table.Right || hand[i].Right == table.Left
                    || hand[i].Right == table.Right)
                    okPlayed.Add(hand[i]);

            List<Token> tokensToAdd = actionModeratorToAdd.TokensToAddThatItIsOk();

            foreach (var token in tokensToAdd)
            {
                if (hand.Contains(token))
                    okPlayed.Add(token);
            }

            List<Token> tokensToSub = actionModeratorToSub.TokensToSubThatItIsNotOk();
            foreach (var token in okPlayed)
                foreach (var token1 in tokensToSub)
                    if (token.Equals(token1))
                    {
                        okPlayed.Remove(token);
                        break;
                    }

            return okPlayed.ToList();
        }
        public static List<Token> BasicTokensGenerator(int start, int end)
        {
            List<Token> total = new List<Token>();

            for (int i = start; i <= end; i++)
                for (int j = i; j <= end; j++)
                    total.Add(new Token(i, j));

            return total;
        }
        public static List<int> ValuesToPlay(List<Token> itIsOkPlayed, Table table)
        {
            List<int> valuesToPlay = new();

            for (int i = 0; i < itIsOkPlayed.Count; i++)
                if (table.Right == itIsOkPlayed[i].Left || table.Left == itIsOkPlayed[i].Left)
                    valuesToPlay.Add(itIsOkPlayed[i].Right);
                else
                    valuesToPlay.Add(itIsOkPlayed[i].Left);

            return valuesToPlay;
        }
        public static List<Token> WinnerTokens(List<Token> itIsOkPlayed, List<int> smartValuesToPlay, Player player, int cursor, Table table)
        {
            List<Token> smartTokens = new();

            foreach (var value in player.IDoNotHaveProvedInGame)
                for (int j = 0; j < smartValuesToPlay.Count; j++)
                    if (value == smartValuesToPlay[j])
                        smartTokens.Add(itIsOkPlayed[j]);

            return smartTokens;
        }
    }
}
