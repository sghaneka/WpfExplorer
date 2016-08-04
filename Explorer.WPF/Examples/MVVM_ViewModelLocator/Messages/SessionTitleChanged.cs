using System;

namespace Explorer.WPF.Examples.MVVM_ViewModelLocator.Messages
{
    public class SessionTitleChanged
    {
        public int SessionId { get; set; }
        public string NewTitle { get; set; }
    }
}                                                                          
