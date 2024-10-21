using Disaster_Response_System.Models.Domain;

public class EvaluationService
{

    public int CalculateScore(RequestForm request)
    {
        int score = 0;

        // urgency and time constraints score
        if (request.Urgency)
        {
            score += 30; 
        }
         
        // Need score
        // 1. Household Composition
        score += request.AdultCount * 10; // Each adult adds 10 points
        score += request.ChildCount * 15; // Each child adds 15 points
        score += request.ElderlyCount * 20; // Each elderly person adds 20 points
        score += request.DisabilityCount * 25; // Each disabled person adds 25 points

        // 2. Housing Status
        switch (request.HousingStatus)
        {
            case "homeless":
                score += 50; // Homeless gets the highest priority
                break;
            case "uninhabitable":
                score += 40; // Uninhabitable house
                break;
            case "damaged":
                score += 30; // Damaged but inhabitable house
                break;
            case "intact":
                score += 10; // House is intact but financial difficulties
                break;
        }

        // 3. Access to Basic Needs
        if (!request.BasicNeedsAccess)
        {
            score += 20; // Add points if basic needs are not available
        }

        // 4. Medical Needs
        if (request.MedicalNeeds)
        {
            score += 30; // Add points if there are urgent medical needs
        }

        return score;
    }
}
