using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Explorer.WPF.Examples.MVVM_MessageBus.Models
{
    public class ConferenceService
    {
        private List<Session> _sessions;

        public ConferenceService()
        {
            _sessions = new List<Session>
            {
                new Session
                {
                    Id = 1,
                    Speaker = "Brian Sullivan",
                    Title = "Real-Time Web Programming with SignalR"
                },
                new Session
                {
                    Id = 2,
                    Speaker = "Caleb Jenkins",
                    Title = "Coding Naked - TDD on the Edge"
                },
                new Session
                {
                    Id = 3,
                    Speaker = "Casey Watson",
                    Title = "Building Massively Scalable Applications with Windows Azure"
                },
                new Session
                {
                    Id = 4,
                    Speaker = "Eric Sowell",
                    Title = "Touchy Browser Applications"
                },
                new Session
                {
                    Id = 5,
                    Speaker = "Latish Sehgal",
                    Title = "The .NET Ninja's Toolbelt"
                }
            };

            for (int i = 0; i < 100; i++)
            {
                _sessions.Add(new Session
                {
                    Id = 100 + i,
                    Speaker = "jaju",
                    Title = "Jaju title " + i.ToString()
                });
            }
        }

        public List<Session> GetSessions()
        {

                return _sessions;
        }

        public Session LoadSession(int sessionId)
        {
            return _sessions.FirstOrDefault(s => s.Id == sessionId);
        }
    }
}
