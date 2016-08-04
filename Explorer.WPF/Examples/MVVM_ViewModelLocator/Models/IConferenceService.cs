using System.Collections.Generic;

namespace Explorer.WPF.Examples.MVVM_ViewModelLocator.Models
{
    public interface IConferenceService
    {
        List<Session> GetSessions();
        Session LoadSession(int sessionId);
    }
}
