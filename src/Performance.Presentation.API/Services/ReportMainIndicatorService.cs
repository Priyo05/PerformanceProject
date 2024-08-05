using Microsoft.EntityFrameworkCore;
using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using Performance.Presentation.API.ViewModels.MainIndicatorAppraisal;

namespace Performance.Presentation.API;
public class ReportMainIndicatorService
{
    private readonly IReportMainIndicatorRepository _reportRepository;

    public ReportMainIndicatorService(IReportMainIndicatorRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }


    public void CreateReport(int userId, int periode)
    {
        Anuallycompetence anuallycompetence = new Anuallycompetence
        {
            UserId = userId,
            Period = periode,
        };

        _reportRepository.CreateReportAnnualyTable(anuallycompetence);

        Workmainindicator workmainindicator = new Workmainindicator
        {
            AnuallycompetencesId = anuallycompetence.Id,
            UserId = userId,
            Period = periode,
            CreatedAt = DateTime.Now

        };

        Basiccompetence basiccompetence = new Basiccompetence
        {
            AnuallycompetencesId = anuallycompetence.Id,
            UserId = userId,
            Period = periode,
            CreatedAt = DateTime.Now
        };

        Responsibilityareaindicator responsibilityareaindicator = new Responsibilityareaindicator
        {
            AnuallycompetencesId = anuallycompetence.Id,
            UserId = userId,
            Period = periode,
            CreatedAt = DateTime.Now
        };

        Additionalindicator additionalindicator = new Additionalindicator
        {
            AnuallycompetencesId = anuallycompetence.Id,
            UserId = userId,
            Period = periode,
            CreatedAt = DateTime.Now
        };

        _reportRepository.CreateReport(workmainindicator, basiccompetence, responsibilityareaindicator, additionalindicator);
    }

    public List<MainIndikatorViewModel> GetAllMainIndicatorByUser(int periode, int userId)
    {
        var result = _reportRepository.GetAllMainIndicatorByUser(periode, userId)
            .Select(c => new MainIndikatorViewModel
            {
                Id = c.Id,
                StrategicObjective = c.StrategicObjective,
                KPI = c.Kpi,
                UnitOfMeasurement = c.UnitOfMeasurement,
                Bobot = c.Bobot,
                Polarisasi = c.Polarisasi,
                Target = c.Target,
                Aktual = c.Aktual,
                TingkatUnjukKerja = c.TingkatUnjukKerja,
                NilaiUnjukKerja = c.NilaiUnjukKerja,
                Periode = c.Period
            }).ToList();

        return result;
    }

    public MainIndikatorViewModel GetMainIndicatorById(int id)
    {
        var result = _reportRepository.GetMainIndicatorById(id);

        return new MainIndikatorViewModel
        {
            Id = result.Id,
            StrategicObjective = result.StrategicObjective,
            KPI = result.Kpi,
            UnitOfMeasurement = result.UnitOfMeasurement,
            Bobot = result.Bobot,
            Polarisasi = result.Polarisasi,
            Target = result.Target,
            Aktual = result.Aktual,
            Periode = result.Period,
            TingkatUnjukKerja = result.TingkatUnjukKerja,
            NilaiUnjukKerja = result.NilaiUnjukKerja
        };
    }

    public Workmainindicator CreateMainIndikator(MainIndikatorViewModel viewModel, int userid, int periode)
    {
        var annualy = _reportRepository.GetAnuallyCompetence(userid, periode);

        double calc = CalculateValue(viewModel.Polarisasi, (int)viewModel.Target, (int)viewModel.Aktual);

        Workmainindicator resutl = new Workmainindicator
        {
            UserId = userid,
            AnuallycompetencesId = annualy.Id,
            StrategicObjective = viewModel.StrategicObjective,
            Kpi = viewModel.KPI,
            UnitOfMeasurement = viewModel.UnitOfMeasurement,
            Bobot = viewModel.Bobot,
            Polarisasi = viewModel.Polarisasi,
            Target = viewModel.Target,
            Aktual = viewModel.Aktual,
            TingkatUnjukKerja = CalculateRating(calc),
            NilaiUnjukKerja = viewModel.Bobot * CalculateRating(calc),
            Period = periode,
            CreatedAt = DateTime.Now
        };

        var insert = _reportRepository.InsertMainIndicator(resutl);

        return insert;
    }

    public MainIndikatorViewModel EditMainIndicator(int id, MainIndikatorViewModel model)
    {

        var getResult = _reportRepository.GetMainIndicatorById(id);

        getResult.StrategicObjective = model.StrategicObjective;
        getResult.Kpi = model.KPI;
        getResult.UnitOfMeasurement = model.UnitOfMeasurement;
        getResult.Bobot = model.Bobot;
        getResult.Polarisasi = model.Polarisasi;
        getResult.Target = model.Target;
        getResult.Aktual = model.Aktual;

        double Calc = CalculateValue(model.Polarisasi, (int)model.Target, (int)model.Aktual);

        getResult.TingkatUnjukKerja = CalculateRating(Calc);

        getResult.NilaiUnjukKerja = model.Bobot * getResult.TingkatUnjukKerja;


        var updated = _reportRepository.Updated(getResult);

        return new MainIndikatorViewModel
        {
            StrategicObjective = updated.StrategicObjective,
            KPI = updated.Kpi,
            UnitOfMeasurement = updated.UnitOfMeasurement,
            Bobot = updated.Bobot,
            Polarisasi = updated.Polarisasi,
            Target = updated.Target,
            Aktual = updated.Aktual,
            Periode = updated.Period
        };
    }

    public Workmainindicator DeleteMainIndicator(int id)
    {
        var getmainIndicator = _reportRepository.GetMainIndicatorById(id);

        var deleted = _reportRepository. DeleteMainIndicator(getmainIndicator);

        return deleted;
    }


    public double CalculateValue(string condition, int target, int aktual)
    {
        double result;
        try
        {
            switch (condition)
            {
                case "Maximum":
                    result = ((double)aktual / target) * 100;
                    return result;

                case "Minimum":
                    result = ((double)target / aktual) * 100;
                    return result;

                case "Stabilize":
                    result = aktual >= target ? 1 * 100 : ((double)aktual / target) * 100;
                    return result;

                default:
                    result = 0;
                    return result;
            }
        }
        catch (Exception)
        {
            return 0;
        }

    }

    public int CalculateRating(double input)
    {
        try
        {
            double value = input;

            if (value > 130)
            {
                return 5;
            }
            else if (value >= 110)
            {
                return 4;
            }
            else if (value >= 91)
            {
                return 3;
            }
            else if (value >= 71)
            {
                return 2;
            }
            else if (value > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception)
        {
            return 0;
        }
    }


}

