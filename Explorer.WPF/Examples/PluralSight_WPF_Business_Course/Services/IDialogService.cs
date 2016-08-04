using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.WPF.Examples.PluralSight_WPF_Business_Course.Services
{
    public interface IDialogService
    {
        bool Prompt(string message);
    }
}
