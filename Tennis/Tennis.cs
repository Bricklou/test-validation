namespace Tenis;

public class Tennis
{
    public string ComputeScores(uint pointsPlayer1, uint pointsPlayer2)
    {
        var transformedPoint1 = TransformPoints(pointsPlayer1);
        var transformedPoint2 = TransformPoints(pointsPlayer2);
        
        if (pointsPlayer1 == pointsPlayer2)
        {
            if (pointsPlayer1 >= 3)
            {
                return "Deuce";
            }
            return transformedPoint1 + "-All";
        }

        if (pointsPlayer1 < 4 && pointsPlayer2 < 4) return transformedPoint1 + "-" + transformedPoint2;

        var minusResult = (int)(pointsPlayer1 - pointsPlayer2);
        return minusResult switch
        {
            1 => "Advantage player A",
            -1 => "Advantage player B",
            >= 2 => "Win for player A",
            _ => "Win for player B"
        };

    }

    public string TransformPoints(uint points)
    {
        if (points == 0) return "Love";
        if (points == 1) return "Fifteen";
        if (points == 2) return "Thirty";
        if (points == 3) return "Forty";

        return "";
    }
}