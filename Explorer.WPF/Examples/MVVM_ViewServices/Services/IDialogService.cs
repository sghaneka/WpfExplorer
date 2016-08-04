using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Explorer.WPF.Examples.MVVM_ViewServices.Services
{
    public interface IDialogService
    {
        bool Prompt(string message);
    }
}
