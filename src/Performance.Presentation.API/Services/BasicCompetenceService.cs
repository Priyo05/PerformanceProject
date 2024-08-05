using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using Performance.Presentation.API.ViewModels.BasicCompetence;

namespace Performance.Presentation.API.Services;
public class BasicCompetenceService
{
    private readonly IBasicCompetenceRepository _competenceRepository;

    public BasicCompetenceService(IBasicCompetenceRepository competenceRepository)
    {
        _competenceRepository = competenceRepository;
    }

    public BasicCompetenceViewModel BasicCompetenceUser(int userid, int periode)
    {
        var resutl = _competenceRepository.GetBasicCompetenceUser(userid, periode);

        var viewModel = new BasicCompetenceViewModel
        {
            CompetenceId = resutl.Id,
            CustomerFocus = resutl.CustomerFocus,
            Improvment = resutl.CountinousImprovement,
            Integrity = resutl.Integrity,
            Teamwork = resutl.Teamwork,
            WorkExcellent = resutl.WorkExcellent,
            TotalValue = resutl.TotalValue,
            Periode = resutl.Period
        };

        return viewModel;
    }

    public Basiccompetence InsertBasicComtence(BasicCompetenceViewModel viewModel,int userid,int periode)
    {
        var getCompetence = _competenceRepository.GetBasicCompetenceUser(userid,periode);

        getCompetence.Integrity = viewModel.Integrity;
        getCompetence.WorkExcellent = viewModel.WorkExcellent;
        getCompetence.CountinousImprovement = viewModel.Improvment;
        getCompetence.CustomerFocus = viewModel.CustomerFocus;
        getCompetence.Teamwork = viewModel.Teamwork;

        int calc = Calculation(viewModel.Integrity, viewModel.WorkExcellent, viewModel.Improvment, viewModel.CustomerFocus, viewModel.Teamwork);
        getCompetence.TotalValue = calc;

        var updated = _competenceRepository.Updated(getCompetence);

        return updated;

    }

    public int Calculation(string? integrity, string? work, string? improv, string? customer, string? teamwork)
    {
        int integrityValue = GetValue(integrity);
        int workValue = GetValue(work);
        int improvValue = GetValue(improv);
        int customerValue = GetValue(customer);
        int teamworkValue = GetValue(teamwork);

        int totalValue = integrityValue + workValue + improvValue + customerValue + teamworkValue;

        return totalValue;
    }

    private int GetValue(string? value)
    {
        switch (value)
        {
            case "Kurang":
                return 20;
            case "Cukup":
                return 70;
            case "Baik":
                return 100;
            default:
                return 0;
        }
    }

}

