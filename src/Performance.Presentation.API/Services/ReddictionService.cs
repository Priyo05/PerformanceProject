

using Microsoft.EntityFrameworkCore;
using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using Performance.Presentation.API.ViewModels.ReductionAdditionAppraisal;

namespace Performance.Presentation.API.Services;
public class ReddictionService
{
    private readonly IReddictionRepository _reddiction;

    public ReddictionService(IReddictionRepository reddiction)
    {
        _reddiction = reddiction;
    }

    public ReddictionIndexViewModel GetReddictionUser(int userId, int periode)
    {
        List<ReddictionViewModel> result;

        var getReddictionReport = _reddiction.GetReddictionUser(userId, periode);

        result = _reddiction.GetReddictionDetail(getReddictionReport.Id)
            .Select(c => new ReddictionViewModel
            {
                id = c.Id,
                IndicatorName = c.IndicatorName,
                IndicatorType = c.IndicatorType,
                value = (int)c.Value
            }).ToList();
        //sss

        return new ReddictionIndexViewModel
        {
            Reddictions = result,
            TotalValue = getReddictionReport.IndikatorTotalValue
        };

    }

    public Indicator InsertReddiction(ReddictionViewModel viewModel, int userid, int periode)
    {
        var getReddictionReport = _reddiction.GetReddictionUser(userid, periode);

        Indicator indicator = new Indicator
        {
            Additionalindicator = getReddictionReport.Id,
            IndicatorName = viewModel.IndicatorName,
            IndicatorType = viewModel.IndicatorType,
            Value = viewModel.value,
        };

        var inserted = _reddiction.Insert(indicator);

        return inserted;

    }

    public void UpdateReddiction(List<ReddictionViewModel> viewModel)
    {
        foreach (var reddiction in viewModel)
        {
            var getIndicator = _reddiction.GetIndicator(reddiction.id);

            getIndicator.IndicatorName = reddiction.IndicatorName;
            getIndicator.IndicatorType = reddiction.IndicatorType;
            getIndicator.Value = reddiction.value;

            var updated = _reddiction.UpdatedIndicator(getIndicator);
        }

    }

    public int GetValueReddiction(string type)
    {
        switch (type)
        {
            case "Pengurangan":
                return -20;
            case "Penambahan":
                return 20;
            default:
                return 0;
        }
    }

}

