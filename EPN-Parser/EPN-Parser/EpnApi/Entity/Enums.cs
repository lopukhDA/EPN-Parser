using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPN_Parser.EpnApi.Entity
{
    public enum ActionRequest
    {
        top_monthly,
        list_categories,
        offer_info,
        search,
        count_for_categories,
        list_currencies
    }

    public enum Currency { USD, UAH, EUR, KZT, BYR, RUR };

    public enum Lang { ru, en };
}
