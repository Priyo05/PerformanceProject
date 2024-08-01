using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using Performance.Web.Blazor.ViewModels;

namespace Performance.Web.Blazor.Services;
public class ReportService
{
    private readonly IReportRepository _reportRepository;

    public ReportService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public Workmainindicator GetMainIndicatorReport(int userid, int periode)
    {
        return _reportRepository.GetMainIndicatorReport(userid,periode);
    }

    public void CreateReport(int userId , int periode)
    {
        Anuallycompetence anuallycompetence = new Anuallycompetence
        {
            UserId = userId,
            Period = periode
        };

        _reportRepository.CreateReportAnnualyTable(anuallycompetence);

        Workmainindicator workmainindicator = new Workmainindicator
        {
            AnuallycompetencesId = anuallycompetence.Id,
            UserId = userId,
            Period = periode
        };

        Basiccompetence basiccompetence = new Basiccompetence
        {
            AnuallycompetencesId = anuallycompetence.Id,
            UserId = userId,
            Period = periode
        };

        Responsibilityareaindicator responsibilityareaindicator = new Responsibilityareaindicator
        {
            AnuallycompetencesId = anuallycompetence.Id,
            UserId = userId,
            Period = periode
        };

        Additionalindicator additionalindicator = new Additionalindicator
        {
            AnuallycompetencesId = anuallycompetence.Id,
            UserId = userId,
            Period = periode
        };

        _reportRepository.CreateReport(workmainindicator,basiccompetence,responsibilityareaindicator,additionalindicator);
    }

    public List<MainIndikatorViewModel> GetAllMainIndicatorByUser(int periode,int userId)
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
                NilaiUnjukKerja = c.NilaiUnjukKerja
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
            Periode = result.Period
        };
    }


    public MainIndikatorViewModel EditMainIndicator(int id,MainIndikatorViewModel model)
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


    public double CalculateValue(string condition, int target, int aktual)
    {
        if (string.IsNullOrEmpty(condition))
        {
            return 0;
        }

        try
        {
            switch (condition)
            {
                case "Maximum":
                    return (aktual / target) * 100;

                case "Minimum":
                    return (target / aktual)*100;

                case "Stabilize":
                    return aktual >= target ? 1*100 : (aktual / target)*100;

                default:
                    return 0;
            }
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public int CalculateRating(double input)
    {
        if (input != null)
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

        return 0;
    }


}

